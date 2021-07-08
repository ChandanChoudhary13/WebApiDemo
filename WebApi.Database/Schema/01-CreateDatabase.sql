IF not exists(select 1 from sys.databases where name = 'EHIDemo')
BEGIN
	CREATE DATABASE EHIDemo
END