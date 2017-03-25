cd/pgsql/bin
set pgport=5344
pg_ctl -D c:/registro start
pg_dump -U saul registroPacientes > c:\registroPacientes.bak
