-- CRIAR A TABELA USUARIO
CREATE TABLE Usuario
(
  IdUsuario INT PRIMARY KEY IDENTITY,
  Email VARCHAR(50) NOT NULL UNIQUE,
  Senha VARCHAR(50) NOT NULL,
  Permissao VARCHAR(30)
)

INSERT INTO Usuario VALUES('admin@admin.com','admin','Administrador'),
							('comum@comum.com','comum','Comum');

SELECT * FROM Usuario

