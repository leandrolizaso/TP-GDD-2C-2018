sqlcmd -S localhost\SQLSERVER2012 -U gdEspectaculos2018 -P gd2018 -i gd_esquema.Schema.sql,gd_esquema.Maestra.Table.sql  -a 32767 -o resultado_output.txt