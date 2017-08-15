/*
Project: Alien-Torpedo
Description: script initial
Author: Renato Crudo
Date: 11/08/2017
*/


declare @servername	varchar(80)
declare @local		varchar(8000)

-- PARA EXECUTAR ALTERAR OS CAMPOS ABAIXO - INI

Set @servername = '.\SQL2008';
/*	Instruções:
Para pasta local, adicione o caminho até a pasta Alien-Torpedo. Ex.:
	Set C:\Users\Renato\Documents\Projetos\Alien-Torpedo
	
	NÃO ADICIONE A \ NO FINAL
*/
Set @local = 'C:\Users\Renato\Documents\Projetos\Alien-Torpedo'; -- ex: 'C:\Users\Renato\Documents\Projetos\Alien-Torpedo'

-- PARA EXECUTAR ALTERAR OS CAMPOS ABAIXO - FIM




declare @Nm_scripts	varchar(8000)

Set @Nm_scripts = 'create_database;create_table;';


if(@Nm_scripts != '')
	begin
		begin try
			-- On
			set nocount on
			exec master.dbo.sp_configure 'show advanced options', 1
			reconfigure
			exec master.dbo.sp_configure 'xp_cmdshell', 1
			reconfigure

				-- create table
				If object_id('tempdb..#Files') is not null
					drop table #Files
						
				Select
					[Cd_file] = ROW_NUMBER() over (order by value)
					, [Nm_file] = value
				Into #Files
				From string_split(@Nm_scripts, ';')
				Where 
					rtrim(value) != '';

				-- declare variaveis

				declare @database varchar(80) = 'controle_compras';
				declare @Nm_file varchar(80);

				Set @local += '\db\';

				declare @path varchar(8000);
				Set @path = 'sqlcmd -S ' + @servername + ' -d ' + @database + ' -i ' + @local
				

				declare @i int = 1;
				declare @total int = (Select count(*) from #Files);

				while (@i <= @total)
					begin
						Set @path = 'sqlcmd -S ' + @servername + ' -d ' + @database + ' -i ' + @local

						Select @Nm_file = Nm_file from #Files Where Cd_file = @i;
						
						--Executando os scripts
						Set @path += @Nm_file + '.sql'
						
						exec xp_cmdshell @path 

						Set @path = '';
											
						Set @i += 1;						 
					end

			-- Off
			exec master.dbo.sp_configure 'xp_cmdshell', 0
			reconfigure
			exec master.dbo.sp_configure 'show advanced options', 0
			reconfigure

			set nocount off

		end try			
		begin catch
			Select 
				[Error_number] = ERROR_NUMBER()
				,[Error_message] = ERROR_MESSAGE()
		end catch
	end
else
	begin
		Select 'Não há scripts para executar!!'
		return
	end