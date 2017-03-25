cd/pgsql/bin
set pgport=5344
createdb -U Monitoreo_Fisico Prueba
psql -U Monitoreo_Fisico Prueba < C:/Registro_Paciente/Prueba.bak


