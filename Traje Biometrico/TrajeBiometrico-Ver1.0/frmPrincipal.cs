using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Threading;
using System.IO;

namespace TrajeBiometrico_Ver1._0
{
    public partial class frmPrincipal : Form
    {
        //Calculo de sesion
        //Constantes medias de consumo de calorias por actividad
        private readonly double aerobic = 0.085;
        private readonly double baileSalon = 0.089;
        private readonly double baloncesto = 0.128;
        private readonly double boxeo = 0.143;
        private readonly double caminar = 0.083;
        private readonly double ciclismo = 0.132;
        private readonly double correr = 0.199;
        private readonly double futbol = 0.164;
        private readonly double spinning = 0.095;
        private readonly double natacion = 0.108;
        private readonly double Tenis = 0.114;

        public List<float> fc = new List<float>();
        public List<float> temp = new List<float>();
        public List<float> humedad = new List<float>();
        public List<float> mov = new List<float>();
        public List<float> flexibilidad = new List<float>();
        public List<float> ph = new List<float>();
        public int tiempo = 0;
        public int id;
        public int typeEnt;
        public string tipoEntrenamiento;

        //Variables locales de la clase
        Process baseDatos = new Process();
        Process processDB = new Process();
        frmAgregarPaciente aux;
        NpgsqlConnection conexion;
        NpgsqlCommand tabla1, tabla2;
        private string server, database, user, pass, port, txtDB, txtPas;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public void finSesion() {
            double kcal;
            kcal = (getPeso(id)) * (tiempo / 60) * this.getActivitiConstant();
            addSesion(getPromFC(), getPromTemp(), getPromPH(), getPromHumedad(), getPromFlexi(), getPromMov(), tipoEntrenamiento, tiempo, (float)kcal, id);
            Enabled = true;
        }

        private float getPromFC()
        {
            float prom = 0;
            foreach (float num in fc)
            {
                prom += num;
            }
            prom = prom / fc.Count();
            return prom;
        }

        private int getPromTemp()
        {
            int prom = 0;
            foreach (int num in temp)
            {
                prom += num;
            }
            prom = prom / temp.Count();
            return prom;
        }

        private float getPromHumedad()
        {
            float prom = 0;
            foreach (float num in humedad)
            {
                prom += num;
            }
            prom = prom / humedad.Count();
            return prom;
        }

        private int getPromMov()
        {
            int prom = 0;
            foreach (int num in mov)
            {
                prom += num;
            }
            prom = prom / mov.Count();
            return prom;
        }

        private float getPromFlexi()
        {
            float prom = 0;
            foreach (float num in flexibilidad)
            {
                prom += num;
            }
            prom = prom / flexibilidad.Count();
            return prom;
        }

        private int getPromPH()
        {
            int prom = 0;
            foreach (int num in ph)
            {
                prom += num;
            }
            prom = prom / ph.Count();
            return prom;
        }

        private double getActivitiConstant()
        {
            double constante = 0;
            switch (typeEnt)
            {
                case 0:
                    constante = this.aerobic;
                    break;
                case 1:
                    constante = this.baileSalon;
                    break;
                case 2:
                    constante = this.baloncesto;
                    break;
                case 3:
                    constante = this.boxeo;
                    break;
                case 4:
                    constante = this.caminar;
                    break;
                case 5:
                    constante = this.ciclismo;
                    break;
                case 6:
                    constante = this.correr;
                    break;
                case 7:
                    constante = this.futbol;
                    break;
                case 8:
                    constante = this.natacion;
                    break;
                case 9:
                    constante = this.spinning;
                    break;
                case 10:
                    constante = this.Tenis;
                    break;
            }
            return constante;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            string path = @"c:\Registro_Paciente";
            if (!System.IO.Directory.Exists(path)){
                Console.WriteLine("Entro :/");
                baseDatos.StartInfo = new ProcessStartInfo("New.bat");
                baseDatos.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                baseDatos.Start();
                do
                {//dont perform anything
                }
                while (!baseDatos.HasExited);
                if (System.IO.File.Exists("CDB.bat"))
                {
                    System.IO.File.Delete("CDB.bat");
                }
                if (System.IO.File.Exists("RCDB.bat"))
                {
                    System.IO.File.Delete("RCDB.bat");
                }
            }
            if (!System.IO.File.Exists("CDB.bat"))
            {
                conectarAToolStripMenuItem.Enabled = false;
            }
            baseDatos.StartInfo = new ProcessStartInfo("arranque.bat");
            baseDatos.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            baseDatos.Start();
            do
            {//dont perform anything
            }
            while (!baseDatos.HasExited);
        }

        /// <summary>
        /// -- getNumberOfSession --
        /// </summary>
        /// <param name="id">  numero entero unico que identifica a un usuario</param>
        /// <returns> retorna el numero actual de sesiones del usuario</returns>
        private int getNumberOfSesions(int id)
        {
            int contador = 0;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) from Sesion where ID_Paciente = "+id+";", conexion);
                contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
            return contador;
        }

        public int buscar(int x) {
            return idExist(x);
        }

        public int buscarS(int x)
        {
            return getNumberOfSesions(x);
        }

        private int idExist(int id) {
            int contador = 0;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) from paciente where ID_Paciente = " + id + ";", conexion);
                contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
            return contador;
        }
        /// <summary>
        /// -- getPeso --
        /// </summary>
        /// <param name="IdPaciente">numero entero unico que identifica a un usuario</param>
        /// <returns>retorna el peso del paciente</returns>
        public double getPeso(int IdPaciente)
        {
            DataTable dt = buscarPaciente(IdPaciente);
            DataRow dr = dt.Rows[0];
            double peso = 0;
            peso = Convert.ToDouble( dr["Peso"].ToString() );
            return peso;

        } 

        /// <summary>
        /// -- Add Sesion --
        /// Metodo que agrega una nueva sesion a un determinado paciente por su id.
        /// </summary>
        /// <param name="fc"> Frecuencia Cardiaca, resultado promedio de la sesion</param>
        /// <param name="temp">Temperatura, resultado moda estadistica de la sesion</param>
        /// <param name="ph"> PH, resultado moda estadistica de la sesion</param>
        /// <param name="humedad"> Humedad, resultado promedio de la sesion</param>
        /// <param name="tipoEntren"> Tipo de entrenamiento, Para calcular las calorias</param>
        /// <param name="timeSesion"> Tiempo de sesion, tiempo total que duro la sesion</param>
        /// <param name="calorias"> Calorias, total de calorias gastadas por el usuario</param>
        /// <param name="id_Paciente"> Id_Paciente, numero entero identificador del paciente que hizo la sesion (autoincremental y hecho por el programa)</param>
        public void addSesion(float fc1, float temp1, int ph1, float humedad1, float flexi1, int mov1, string tipoEntren, float timeSesion, float calorias,int id_Usuario)
        {
            int id_sesion = 0;
            string comando = "";
            id_sesion += this.getNumberOfSesions(id_Usuario);
            comando = "insert into sesion values(" + id_sesion + "," + fc1 + ", " + temp1 + "," + ph1 + "," + humedad1+ ","+ flexi1 + "," + mov1 + ",'" + tipoEntren + "',"+ timeSesion +","+calorias+","+id_Usuario+");";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(comando, conexion);
                cmd.ExecuteNonQuery();
                fc.Clear();
                temp.Clear();
                humedad.Clear();
                mov.Clear();
                flexibilidad.Clear();
                ph.Clear();
                tiempo = 0;
    }
            catch (Exception msg)
            {
                //MessageBox.Show("No se pudo agregar sesion al paciente\n" + msg.ToString(), "Error de conexion postgreSQL");
            }
        }

        /// <summary>
        /// -- getSesion --
        /// </summary>
        /// <param name="id">  numero entero unico que identifica a un usuario usado para encontrar las sesiones</param>
        /// <returns> retorna la tabla de todas las sesiones guardadas del usuario</returns>
        public DataTable getSesion(int id)
        {
        	DataTable memoria = new DataTable();
            try
            {
                NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select * from sesion where ID_Paciente = "+id, conexion);
                datosConsulta.Fill(memoria);
                return memoria;
            }
            catch (Exception msg)
            {
                return null;
            }
        }
        
        /// <summary>
        /// -- buscarPaciente --
        /// </summary>
        /// <param name="id"> numero entero unico que identifica a un usuario</param>
        /// <returns> retorna la tabla con los datos del usuario buscado</returns>
        public DataTable buscarPaciente(int id)
        {
        	DataTable memoria = new DataTable();
            try
            {
                NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select * from paciente where ID_Paciente=" + id+";", conexion);
                datosConsulta.Fill(memoria);
                return memoria;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                return null;
            }
        }

        /// <summary>
        /// -- eliminarPaciente --
        /// </summary>
        /// <param name="id"> numero entero unico que identifica a un usuario</param>
        /// <returns> </returns>
        public string eliminarPaciente(int id)
        {
            string msj = "";
            DialogResult dr = MessageBox.Show("Esta seguro de que dese eliminar este paciente?\nRecuerde que no se podran recuperar los datos despues.","Advertencia!",MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("delete from paciente where ID_Paciente="+id, conexion);
                    cmd.ExecuteNonQuery();
                    msj = "¡¡Exito al eliminar!!";
                }
                catch (Exception msg)
                {
                    msj = msg.ToString();
                }
                return msj;
            }
            else if (dr == DialogResult.No)
                return "No selected";
            return "";
        }

        /// <summary>
        /// -- mostrarRegistroPacientes --
        /// 
        /// Muestra todos los registros contenidos en la base de datos
        /// y los coloca en el dataGridView
        /// </summary>
        public void mostrarRegistrosPacientes()
        {
            DataTable memoria = new DataTable();
            try
            {
                NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select * from paciente", conexion);
                datosConsulta.Fill(memoria);
                dgvMostrar.DataSource = memoria.DefaultView;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
        }
        
        /// <summary>
        /// -- getNumberOfPatiens --
        /// </summary>
        /// <returns> el numero actual de pacientes en la base de datos</returns>
        private int getNumberOfPatients()
        {
            int contador = 0;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(*) from paciente", conexion);
                contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
            return contador;
        }

        /// <summary>
        /// -- addPacient --
        /// </summary>
        /// <param name="name"> nombre del usuario</param>
        /// <param name="edad"> edad del usuario en enteros</param>
        /// <param name="altura"> altura del usuario en cm</param>
        /// <param name="peso"> peso del usuario en kg</param>
        /// <param name="genero"> genero del usuario m o h</param>
        /// <returns></returns>
        public Boolean addPacient(string name,int edad, double altura, double peso, string genero)
        {
            int id = 1;
            string comando = "";
            Boolean error = false;
            comando = "insert into paciente (Nombre,Edad,altura,peso,genero) values("+"'" + name + "', " + edad + "," + altura + "," + peso + ",'" + genero.ElementAt(0) + "');";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(comando, conexion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                error = true;
                MessageBox.Show("No se pudo agregar paciente\n"+msg.ToString(),"Error de conexion postgreSQL");
            }
            if(error == false)
            {
                MessageBox.Show("¡¡Paciente agregado satisfactoriamente!!");
            }
            return error;
        }

        public Boolean updatePacient(int id,string name, int edad, double altura, double peso, string genero)
        {
            string comando = "";
            Boolean error = false;
            //Console.Write(altura);
            comando = "update paciente set (Nombre, Edad, altura, peso, genero) = ("+"'" + name + "', " + edad + ", " + altura + ", " + peso + ", '" + genero.ElementAt(0) + "') where ID_Paciente="+id+";";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(comando, conexion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                error = true;
                MessageBox.Show("No se pudo modificar el paciente\n" + msg.ToString(), "Error de conexion postgreSQL");
            }
            if (error == false)
            {
                MessageBox.Show("¡¡Paciente Modificado!!");
            }
            return error;
        }

        /// <summary>
        /// --  frmPrincipal_FormClosed --
        /// Metodo llamado a la hora de cerrar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeConexion();
            Application.Exit();
        }

        /// <summary>
        /// -- salirToolStripMenuItem --
        /// Metodo que cierra la sesion adecuadamente en 
        /// cuanto es presionado el item en el menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// -- agregarToolStripMenuItem --
        /// Metodo que crea la instancia del objeto de la
        /// ventana frmAgregar y esconde esta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aux = new frmAgregarPaciente(this);
            aux.Show();
        }

        /// <summary>
        /// -- BuscarToolStripMenuItem --
        /// Metodo que crea la instancia del objeto de la
        /// ventana frmbuscar y esconde la ventana principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BuscarToolStripMenuItemClick(object sender, EventArgs e)
		{
			frmObtenerID oID = new frmObtenerID(this,1);
			oID.Show();
			this.Enabled = false;
		}
        
        /// <summary>
        /// -- createBackUp --
        /// Metodo que crea el .bat para realizar un respaldo 
        /// de la base de datos del sistema y lo ejecuta
        /// </summary>
        /// <param name="dumpPath"></param>
        /// <param name="filePath"></param>
        private void createBackup(string filePath)
        {
            try
            {
                using (StreamWriter tw = new StreamWriter("DBBackup.bat"))
                {
                    tw.WriteLine("cd/pgsql/bin");
                    tw.WriteLine("set pgport=5344");
                    tw.WriteLine("pg_dump -U Monitoreo_Fisico "+database+" > c:/Registro_Paciente/"+database+".bak");
                    tw.WriteLine("\n");
                }
                processDB.StartInfo = new ProcessStartInfo("DBBackup.bat");
                processDB.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processDB.Start();
                //dont perform anything
                do { }
                while (!processDB.HasExited);
                {
                    string sourceFile = @"c:/Registro_Paciente/" + database + ".bak";
                    string destinationFile = filePath;

                    // To move a file or folder to a new location:
                    System.IO.File.Move(sourceFile, destinationFile);
                    MessageBox.Show(this.conexion.Database + " Successfully Backed up at " + filePath + "\n\n\n");
                    this.SetTopLevel(true);
                }
            }
            catch (Exception ex){
            }
        }

        /// <summary>
        /// Metodo encargado de cerrar la conexion con Postgresql
        /// </summary>
        private void closeConexion()
        {
            try

            {
                baseDatos.StartInfo = new ProcessStartInfo("detener.bat");
                baseDatos.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                baseDatos.Start();
                baseDatos.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Metodo que asigna los valores para la conexion y manda
        /// a conecarse con los valores ya asignados
        /// </summary>
        /// <param name="servidor"> Nombvre del servidor postgresql del equipo</param>
        /// <param name="db"> Nombre de la base de datos</param>
        /// <param name="username"> Nombre del usuario de postgres que tiene el control sobre la base de datos</param>
        /// <param name="password"> Contraseña (en caso de tenerla) del usuario</param>
        /// <param name="puerto"> Puerto del equipo al cual conectarse</param>
        public void setConectionValues(string db){
            this.server = "localhost";
            this.database = db;
            this.user = "Monitoreo_Fisico";
            this.pass = "";
            this.port = "5344";
            setNewConexion();
        }

        /// <summary>
        /// Metodo que crea la conexion con postgresql
        /// y se abre la conexion con la base de datos
        /// </summary>
        private void setNewConexion()
        {
            baseDatos.StartInfo = new ProcessStartInfo("arranque.bat");
            baseDatos.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            baseDatos.Start();
            do { }
            while (!baseDatos.HasExited);{
            }
            this.conexion = new NpgsqlConnection("Server= " + server + ";"+ "Database= " + database + ";" +"User ID= " + user + ";" + "Port= " + port);
            this.conexion.Open();
            try
            {
                try
                {
                    MessageBox.Show("Exito al abrir la conexión","Conection to DB succefull!!",MessageBoxButtons.OK);
                    this.agregarToolStripMenuItem.Enabled = true;
                    this.buscarToolStripMenuItem.Enabled = true;
                    this.eliminarToolStripMenuItem.Enabled = true;
                    this.pacienteToolStripMenuItem.Enabled = true;
                    this.guardarToolStripMenuItem.Enabled = true;
                    this.restaurarToolStripMenuItem.Enabled = true;
                    this.conectarAToolStripMenuItem.Enabled = true;
                    this.modificarToolStripMenuItem.Enabled = true;
                    mostrarRegistrosPacientes();
                }
                catch(Exception ex1)
                {
                    MessageBox.Show("Error al esperar conexion.\n\n"+ex1.ToString(), "Error en Hilo", MessageBoxButtons.OK);
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Error al conectarse a la base de datos.\n" + msg.ToString(), "Error de conexion", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Metodo que manda a crear el backup de la base de datos
        /// primero preguntando al usuario si desea hacer el mismo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de crear el back up de la base de datos?\nSi elige Si porfavor no cambie el nombre del archivo.","Guardarcambios",MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "BAK file|*.bak";
                sfd.Title = "Guardar tu respaldo de la Base de datos";
                sfd.FileName = database;
                
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    string fn = sfd.FileName;
                    Console.WriteLine(fn);
                    if (!System.IO.File.Exists(fn))
                    {
                        createBackup(fn);
                    }
                    else {
                        System.IO.File.Delete(fn);
                        createBackup(fn);
                    }
                }
            }
        }

        /// <summary>
        /// -- eliminarToolStripMenuItem --
        /// Metodo que crea la instancia del objeto de la
        /// ventana frmObtenerId y esconde esta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObtenerID oID = new frmObtenerID(this,2);
            oID.Show();
            this.Enabled = false;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObtenerID oID = new frmObtenerID(this, 3);
            oID.Show();
            this.Enabled = false;
        }

        private void nuevaBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewDB nc = new frmNewDB(this);
            nc.Show();
        }

        public void setNewDB_V(string txtNDB, string txtPasDB){
            txtDB = txtNDB;
            txtPas = txtPasDB;
            database = txtNDB;
            pass = txtPas;
            setNewDB();
        }

        private void setNewDB()
        {
            using (StreamWriter tw = File.CreateText("nuevaDB.bat"))
            {
                tw.WriteLine("cd/pgsql/bin");
                tw.WriteLine("set pgport=5344");
                tw.WriteLine("createdb -U Monitoreo_Fisico " + txtDB);
                tw.WriteLine("\n");
            }
            try {
                processDB.StartInfo = new ProcessStartInfo("nuevaDB.bat");
                processDB.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processDB.Start();
                do
                {//dont perform anything
                }
                while (!processDB.HasExited);
                baseDatos.StartInfo = new ProcessStartInfo("arranque.bat");
                baseDatos.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                baseDatos.Start();
                do
                {//dont perform anything
                }
                while (!baseDatos.HasExited);
                try
                {
                    Thread.Sleep(2000);
                    this.conexion = new NpgsqlConnection("Server=" + "localhost" + ";"+ "Database=" + txtDB + ";" 
                        + "User ID=" + "Monitoreo_Fisico"+";" + "Port=" + "5344");
                    this.conexion.Open();
                    tabla1 = new NpgsqlCommand("CREATE TABLE paciente (ID_Paciente serial primary key,Nombre varchar(50) NOT NULL,Edad integer NOT NULL,Altura double precision NOT NULL,Peso double precision NOT NULL,Genero character(1) NOT NULL);", conexion);
                    tabla2 = new NpgsqlCommand("CREATE TABLE sesion (ID_Sesion integer NOT NULL,Frecuencia_Cardiaca double precision NOT NULL,Temperatura double precision NOT NULL,PH integer NOT NULL,Humedad double precision NOT NULL,Flexibilidad double precision NOT null,Movimiento integer NOT null, Actividad varchar(50) NOT NULL,Duracion double precision NOT NULL,Calorias double precision NOT NULL,ID_Paciente integer not null references paciente(ID_Paciente));",conexion);
                    tabla1.ExecuteNonQuery();
                    tabla2.ExecuteNonQuery();
                    MessageBox.Show("Exito al crear y abrir la conexión", "Operación completa", MessageBoxButtons.OK);
                    if (System.IO.File.Exists("CDB.bat"))
                    {
                        using (StreamWriter sw = File.AppendText("CDB.bat"))
                        {
                            sw.WriteLine(txtDB);
                            sw.Close();
                        }
                        using (StreamWriter sw = File.AppendText("RCDB.bat"))
                        {
                            sw.WriteLine(txtPas);
                            sw.Close();
                        }
                        File.SetAttributes("CDB.bat", FileAttributes.Hidden);
                        File.SetAttributes("RCDB.bat", FileAttributes.Hidden);
                    }
                    else {
                        using (StreamWriter tw = File.CreateText("CDB.bat"))
                        {
                            tw.WriteLine(txtDB);
                            tw.Close();
                        }
                        using (StreamWriter sw = File.AppendText("RCDB.bat"))
                        {
                            sw.WriteLine(txtPas);
                            sw.Close();
                        }
                        File.SetAttributes("CDB.bat", FileAttributes.Hidden);
                        File.SetAttributes("RCDB.bat", FileAttributes.Hidden);
                    }

                    this.agregarToolStripMenuItem.Enabled = true;
                    this.buscarToolStripMenuItem.Enabled = true;
                    this.eliminarToolStripMenuItem.Enabled = true;
                    this.pacienteToolStripMenuItem.Enabled = true;
                    this.guardarToolStripMenuItem.Enabled = true;
                    this.restaurarToolStripMenuItem.Enabled = true;
                    this.conectarAToolStripMenuItem.Enabled = true;
                    this.modificarToolStripMenuItem.Enabled = true;
                    mostrarRegistrosPacientes();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error al esperar conexion.\n\n" + ex1.ToString(), "Error en Hilo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error al crear la base de datos.\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Metodo que destruye la base de datos para 
        /// posteriormente hacer un restore de la misma
        /// </summary>
        /// <param name="dbName"> Nombre de la base de datos para eliminar</param>
        private Boolean dropDataBase(string dbName)
        {
            try
            {
                //check for the pre-requisites before restoring the database.*********
                if (dbName != ""){

                    using (StreamWriter tw = new StreamWriter("DBdropdb.bat"))
                    {
                        tw.WriteLine("cd/pgsql/bin");
                        tw.WriteLine("set pgport=5344");
                        tw.WriteLine("dropdb -U Monitoreo_Fisico " + dbName);
                    }
                    processDB.StartInfo = new ProcessStartInfo("DBdropdb.bat");
                    processDB.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processDB.Start();
                    do
                    {//dont perform anything
                    }
                    while (!processDB.HasExited);
                    {
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the Database name!");
                    return false;
                }
            }
            catch (Exception ex){ }
            return false;
        }

        /// <summary>
        /// Metodo que restaura la base de datos por medio 
        /// de un archivo *.bak
        /// </summary>
        /// <param name="restorePath"> Es la ruta del restordb.exe de postgresql</param>
        /// <param name="filePath"> Ruta del archivo *.bak</param>
        private void restoreDataBase(string filePath)
        {
            try
            {
                //check for the pre-requisites before restoring the database.*********
                if (conexion.Database!= "")
                {
                    if (filePath != "")
                    {

                        using (StreamWriter tw = new StreamWriter("DBRestore.bat"))
                        {
                            tw.WriteLine("cd/pgsql/bin");
                            tw.WriteLine("set pgport=5344");
                            tw.WriteLine("createdb -U Monitoreo_Fisico "+database);
                            tw.WriteLine("psql -U Monitoreo_Fisico "+database+" < " + "C:/Registro_Paciente/"+database+".bak");
                            tw.WriteLine("\n");
                        }
                        string destinationFile = @"c:/Registro_Paciente/" + database + ".bak";
                        string sourceFile = filePath;
                        // To move a file or folder to a new location:

                        System.IO.File.Move(sourceFile, destinationFile);
                        processDB.StartInfo = new ProcessStartInfo("DBRestore.bat");
                        processDB.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        processDB.Start();
                        do{//dont perform anything
                        }
                        while (!processDB.HasExited);
                        {
                            System.IO.File.Move(destinationFile,sourceFile);
                            MessageBox.Show("Successfully restored "+conexion.Database+" Database from " + filePath+"\n\n\n");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the Database name to Restore!");
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// MEtodo que manda a ejecutar la restauracion 
        /// de la base de datos eligiendo primero un archivo *.bak
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de que desea restaurar la base de datos?\nLos datos actuales podrian perderse.", "Restaurar Base de datos", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "BAK file|*.bak";
                ofd.Title = "Selecciona el archivo backup a utilizar";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fn = ofd.FileName;
                    string fn1 = ofd.SafeFileName;
                    if (fn1.Substring(0, fn1.Length - 4).CompareTo(database) != 0)
                        MessageBox.Show("El nombre del archivo debe ser el mismo nombre que la base de datos.\n\n\nBase de datos: "+conexion.Database+"\nFile name: "+ fn1.Substring(0, fn1.Length - 4)+"  .bak");
                    else
                    {
                        baseDatos.StartInfo = new ProcessStartInfo("detener.bat");
                        baseDatos.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        baseDatos.Start();
                        do
                        {//dont perform anything
                        }
                        while (!baseDatos.HasExited);
                        baseDatos.StartInfo = new ProcessStartInfo("arranque.bat");
                        baseDatos.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        baseDatos.Start();
                        do
                        {//dont perform anything
                        }
                        while (!baseDatos.HasExited);
                        if (dropDataBase(database)) {
                            restoreDataBase(fn);
                        }
                        try{
                            this.conexion = new NpgsqlConnection("Server=" + "localhost" + ";" + "Database=" + database + ";"
                        + "User ID=" + "Monitoreo_Fisico" + ";" + "Port=" + "5344");
                            this.conexion.Open();
                            mostrarRegistrosPacientes();
                        }
                        catch (Exception ex){
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que crea la instancia del objeto de la
        /// ventana frmNuevaConexcion y oculta la venta principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conectarAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevaConexion nc = new frmNuevaConexion(this);
            nc.Show();
        }
    }
}
