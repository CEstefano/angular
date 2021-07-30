select * From Sector;
select * From Zona;
select * From Persona;

INSERT INTO Sector (des_sector) 
VALUES ('Sur'), ('Norte')

INSERT INTO Zona(SectorId,des_zona) 
VALUES 
('2', 'Garzota'), 
('2','Nueva Prosperina'),
('2','Guasmo'),
('2', 'Trinitaria'),
('1', 'Coop 9 de octubre'), 
('1', 'La joya'),
('1', 'La puntilla'),
('1', 'Via a la Costa')

INSERT INTO Persona (nombre,fec_nacimiento,SectorId,ZonaId,Sueldo) VALUES ('minerva chavez', '12/01/49','1','5','1200'),
('Estefano Cralos', '12/01/50','2','1','300'),('Carlos Andrade', '12/01/98','1','7','900.20'),
('minerva chavez', '11/09/65','1','8','600.80'),('Caicedo Bryan', '12/01/99','2','2','678.90')

Select des_sector ,des_zona , Persona.Sueldo , Persona.fec_nacimiento, Persona.nombre FROM  Sector , Zona , Persona WHERE Persona.SectorId= Sector.Id
AND Persona.ZonaId= Zona.Id AND 
DATEDIFF(YEAR,Persona.fec_nacimiento,GETDATE())
-(CASE
   WHEN DATEADD(YY,DATEDIFF(YEAR,Persona.fec_nacimiento,GETDATE()),fec_nacimiento)>GETDATE() THEN
      1
   ELSE
      0 
   END) > 65