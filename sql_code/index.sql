CREATE INDEX IxTituloTarefa ON PROJETO.Tarefa(titulo);
CREATE INDEX IxNomeGrupo ON PROJETO.Grupo(nome);
CREATE INDEX IxTituloPagina ON PROJETO.Pagina(titulo);
CREATE INDEX IxNomeInstituicao ON PROJETO.Instituicao(nome) WHERE disabled = 0;
CREATE INDEX IxNomeCadeira ON PROJETO.Cadeira(nome) WHERE disabled = 0;