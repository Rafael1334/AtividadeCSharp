create database atividade4SecGlobal;
use atividade4SecGlobal;

create table pessoa (
	id_pessoa int AUTO_INCREMENT PRIMARY KEY,
    nome varchar(125) NOT NULL,
    cpf varchar(11) NOT NULL UNIQUE,
    rg varchar(9),
    dataNascimento varchar(10),
    idade int,
    sexo varchar(20),
    profissao varchar(55),
    escolaridade varchar(55)
);

create table endereco (
	id_endereco int AUTO_INCREMENT PRIMARY KEY,
    id_pessoa int NOT NULL,
	logradouro varchar(255) NOT NULL,
    numeroCasa varchar(20),
    complemento varchar(255),
    bairro varchar(255),
    cidade varchar(255),
    estado varchar(2),
    FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
);

create table telefone (
	id_telefone int AUTO_INCREMENT PRIMARY KEY,
    id_pessoa int NOT NULL,
	ddd varchar(3),
    numeroTelefone varchar(15) NOT NULL,
    operadora varchar(50),
    FOREIGN KEY (id_pessoa) REFERENCES pessoa(id_pessoa)
);

INSERT INTO pessoa (nome, cpf, rg, dataNascimento, idade, sexo, profissao, escolaridade) 
VALUES 
("João Silva", "12345678901", "123456789", "27/08/2004", 20, "Masculino", "Engenheiro", "Superior Completo");

INSERT INTO endereco (id_pessoa, logradouro, numeroCasa, complemento, bairro, cidade, estado) 
VALUES 
(1, "Rua das Flores", "123", "Apto 202", "Centro", "São Paulo", "SP");
INSERT INTO endereco (id_pessoa, logradouro, numeroCasa, complemento, bairro, cidade, estado) 
VALUES 
(1, "Rua das Dores", "155", "Apto 2", "Centro", "Curitiba", "PR");

INSERT INTO telefone (id_pessoa, ddd, numeroTelefone, operadora) 
VALUES 
(1, "11", "987654321", "Vivo");
INSERT INTO telefone (id_pessoa, ddd, numeroTelefone, operadora) 
VALUES 
(1, "041", "94412407", "Tim");

SELECT 
    p.id_pessoa, 
    p.nome, 
    p.cpf, 
    p.rg, 
    p.dataNascimento, 
    p.idade, 
    p.sexo, 
    p.profissao, 
    p.escolaridade,
    COALESCE(GROUP_CONCAT(CONCAT(e.logradouro, ' ', e.numeroCasa, ' ', e.complemento, ' ',  e.bairro, ' ',  e.cidade, ' ', 
    e.estado, ' ') SEPARATOR '; '), 'Sem telefone') AS enderecos,
    COALESCE(GROUP_CONCAT(CONCAT(t.ddd, ' ', t.numeroTelefone, ' (', t.operadora, ')') SEPARATOR '; '), 'Sem telefone') AS telefones
FROM pessoa p
LEFT JOIN endereco e ON p.id_pessoa = e.id_pessoa
LEFT JOIN telefone t ON p.id_pessoa = t.id_pessoa
WHERE p.id_pessoa = 1
GROUP BY 
    p.id_pessoa, e.id_endereco;

