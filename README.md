<h1 align="center">
  <br>
  <a href="https://www.lamia.sh.utfpr.edu.br/">
    <img src="https://user-images.githubusercontent.com/26206052/86039037-3dfa0b80-ba18-11ea-9ab3-7e0696b505af.png" alt="LAMIA - Laboratório de                  Aprendizagem de Máquina e Imagens Aplicados à Indústria" width="400"></a>
<br> <br>
E-Battle

</h1>
<p align="center">
  <a href="https://www.lamia.sh.utfpr.edu.br/">
    <img src="https://img.shields.io/badge/Follow-Lab%20Page-blue" alt="Lab">
  </a>
</p>

<p align="center">
<b>Equipe:</b>  
<br>
Thiago Naves <a href="https://github.com/tfnaves" target="_blank"> (Naves, T. F.)</a> - Coordenador  <br>
Wagner Destro <a href="https://github.com/wagnerDestro" target="_blank">(Destro, W. L. S.)</a> - Membro Líder<br>
Heitor Vilas Boas <a href="https://github.com/heitorVilasBoas" target="_blank">(Vilas Boas, H. R. B. H. C. S.)</a> - Membro Líder <br>
</p>

<p align="center">  
<b>Grupo</b>: <a href="https://www.lamia.sh.utfpr.edu.br/" target="_blank">LAMIA - Laboratório de Aprendizado de Máquina e Imagens Aplicados à Indústria </a> <br>
<b>Email</b>: <a href="mailto:lamia-sh@utfpr.edu.br" target="_blank">lamia-sh@utfpr.edu.br</a> <br>
<b>Organização</b>: <a href="http://portal.utfpr.edu.br" target="_blank">Universidade Tecnológica Federal do Paraná</a> <a href="http://www.utfpr.edu.br/campus/santahelena" target="_blank"> - Campus Santa Helena</a> <br>
</p>

<p align="center">
<br>
Status do Projeto: Em desenvolvimento :warning:
</p>

# Resumo
O projeto consiste em desenvolver um jogo digital com base em uma dinâmica de tabuleiro para uso em sala de aula para testar conhecimentos dos alunos de forma individual ou em grupo. O projeto possui os diferenciais de utilizar recursos de efeitos visuais da engine Unity e não utilizar conteúdos de aprendizado estáticos, sendo possível o professor customizar os conteúdos de conhecimento que são utilizados no jogo. 

## Objetivo
O objetivo principal do projeto E-Battle é o de estimular o aprendizado em sala de aula através da competitividade saudável entre os jogadores. O grande diferencial do projeto está justamente na total personalização do conteúdo das perguntas realizadas durante a partida, que ficará a cargo do aplicador/professor.


## Como Utilizar
Para clonar e executar a aplicação é necessário baixar a ferramenta Unity, uma das mais famosas game engine utilizadas atualmente. A versão utilizada da game engine para o desenvolvimento do projeto é a 2019.4.13f1.
O banco de dados utilizado para o desenvolvimento do projeto é o PostgreSQL, que atualmente ainda está hospedado localmente, portanto, para testar a versão atual também é necessário realizar o download do pgAdmin 4.

As configurações necessárias para realizar a criação do banco são as seguintes:

```bash
 "Server=127.0.0.1;" +
 "Database=e-battle;" +
 "User ID=postgres;" +
 "Password=senha;";
```

As tabelas existentes na versão atual do projeto são: <i>perguntas</i> e <i>temas</i>

tabela <i>perguntas</i>:

```bash
  CREATE TABLE public.perguntas
(
    id_pergunta SERIAL,
    id_tema integer NOT NULL,
    texto_pergunta text COLLATE pg_catalog."default" NOT NULL,
    alternativas text COLLATE pg_catalog."default",
    CONSTRAINT perguntas2_pkey PRIMARY KEY (id_pergunta)
)

TABLESPACE pg_default;

ALTER TABLE public.perguntas
    OWNER to postgres;

```

tabela <i>temas</i>:
```bash
  
CREATE TABLE public.temas
(
    id_tema SERIAL,
    nome text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT temas_pkey PRIMARY KEY (id_tema)
)

TABLESPACE pg_default;

ALTER TABLE public.temas
    OWNER to postgres;
```

## Tecnologias

E-Battle usa as seguintes tecnologias:

* [Unity](https://unity3d.com/pt/get-unity/download/archive) - game engine utilizada no desenvolvimento
* [PgAdmin 4](https://www.pgadmin.org/download/) - banco de dados utilizado atualmente no desenvolvimento

## Citação

Se você utliza e quer citar o projeto em sua pesquisa, por favor utilize o formato de citação abaixo:
    
    @inproceedings{LAMIA_ict01,
      title={E-Battle},
      author={Naves, T. F.; DESTRO, W. L. S.; VILAS BOAS, H. R. B. H. C. S.},
      journal={IEEE Conference on Big Data},
      year={2019}
    }
