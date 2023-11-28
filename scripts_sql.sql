create table public.produto
(
	id varchar(48) primary key,
	nome varchar not null,
	rendimento_mensal decimal not null
);

create table public.aplicacao
(
	id varchar(48) primary key,
	id_produto varchar(48) not null,
	valor decimal not null,
	data_aplicacao timestamp not null
);

ALTER TABLE public.aplicacao ADD CONSTRAINT id_produto_fk FOREIGN KEY (id_produto) REFERENCES public.produto(id);

create table public.resgate
(
	id varchar(48) primary key,
	id_aplicacao varchar(48) not null,
	valor decimal not null,
	ir decimal not null,
	data_aplicacao timestamp not null
);

ALTER TABLE public.resgate ADD CONSTRAINT id_aplicacao_fk FOREIGN KEY (id_aplicacao) REFERENCES public.aplicacao(id);

