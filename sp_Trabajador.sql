
alter procedure sp_trabajador
(
@idEmpresa int null,
@estadoCivil varchar(50),
@fechaInicio date,
@fechaFin date
)
AS
BEGIN
	select Trabajador.idTrabajador, 
		Trabajador.nombres, 
		Trabajador.apellidos, 
		Trabajador.tipoDocumento,
		Trabajador.numeroDocumento, 
		Trabajador.direccion, 
		Trabajador.correo, 
		Trabajador.idEmpresa, 
		Empresa.razonSocial,
		Trabajador.fechaNacimiento,
		Trabajador.estado,
		CASE 
		  WHEN Trabajador.estadoCivil = 'S' THEN 'Soltero'
		  WHEN Trabajador.estadoCivil = 'C' THEN 'Casado'
		  ELSE 'Viudo'
		  END AS estadoCivil
		from Trabajador 
		inner join Empresa on Trabajador.idEmpresa = Empresa.idEmpresa
		where Trabajador.idEmpresa = CASE WHEN isnull(@idEmpresa,'') = '' THEN Trabajador.idEmpresa ELSE @idEmpresa END 
		and Trabajador.estadoCivil = CASE WHEN isnull(@estadoCivil,'') = '' THEN Trabajador.estadoCivil ELSE @estadoCivil END 
		and Trabajador.fechaNacimiento between @fechaInicio and @fechaFin
END

select * from Trabajador