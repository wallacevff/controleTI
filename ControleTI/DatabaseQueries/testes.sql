use controleti;
INSERT INTO tipodispositivo(Tipo) VALUES('NOTEBOOK');
INSERT INTO dispositivo(Nome,IdTipo) VALUES('NOTE-89A5',1);
DELETE FROM dispositivosoftware;
INSERT INTO dispositivosoftware(DispositivoId, SoftwareId, SerialKeyId) VALUES(8,1,2);
INSERT INTO dispositivosoftware(DispositivoId, SoftwareId, SerialKeyId) VALUES(8,2,3);
INSERT INTO dispositivosoftware(DispositivoId, SoftwareId, SerialKeyId) VALUES(9,1,2);
INSERT INTO dispositivosoftware(DispositivoId, SoftwareId, SerialKeyId) VALUES(9,2,3);