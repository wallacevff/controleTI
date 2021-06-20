USE controleti;
DELIMITER $$
CREATE TRIGGER TGR_INS_UTILIZADA_SERIALKEY after insert ON dispositivosoftware FOR EACH ROW
BEGIN	
	update serialkey set Utilizadas = Utilizadas+1 where id = new.SerialKeyId;
    update serialkey set Restantes = Quantidade - Utilizadas where id = new.SerialKeyId;
END$$

DELIMITER $$
CREATE TRIGGER 	TGR_UPD_UTILIZADA_SERIALKEY after update ON dispositivosoftware FOR EACH ROW
BEGIN	
	update serialkey set Utilizadas = Utilizadas+1 where id = new.SerialKeyId;
    update serialkey set Restantes = Quantidade - Utilizadas where id = new.SerialKeyId;
END$$

DELIMITER $$
CREATE TRIGGER 	TGR_DLT_UTILIZADA_SERIALKEY before delete ON dispositivosoftware FOR EACH ROW
BEGIN	
	update serialkey set Utilizadas = Utilizadas-1 where id = old.SerialKeyId;
    update serialkey set Restantes = Quantidade - Utilizadas where id = old.SerialKeyId;
END$$

DELIMITER $$
CREATE TRIGGER 	TGR_DLT_DISPOSITIVOSOFTWARE before delete ON dispositivo FOR EACH ROW
BEGIN 
	DELETE FROM dispositivosoftware where DispositivoId = old.id;
END$$

DELIMITER $$
CREATE TRIGGER 	TGR_UPD_DISPOSITIVOSOFTWARE before update ON dispositivosoftware FOR EACH ROW
BEGIN 
IF(NEW.softwareId != OLD.softwareId) THEN
	update  dispositivosoftware set SerialKeyId = null where id = NEW.id;
END IF;
END$$
DELIMITER ;