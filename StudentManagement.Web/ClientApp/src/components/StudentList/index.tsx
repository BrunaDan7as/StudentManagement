import React, { useState } from 'react';
import { Button, ModalBody, ModalFooter, ModalHeader, ModalTitle } from 'react-bootstrap';
import Modal from 'react-bootstrap/Modal';
import DeleteButtonConfirm from '../ConfirmDelete';
import { studentModel } from '../../models/studentModel';
import DataTable from 'react-data-table-component';
import dayjs from 'dayjs';
const StudentList: React.FC = () => {
  const [showModal, setShowModal] = useState(false);
  const [updateStudent, setUpdateStudent] = useState({} as studentModel);

  const handleCloseModal = () => {
    setShowModal(false);
  };

  const handleOpenModal = () => {
    setShowModal(true);
  };


  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    // Lógica para salvar os dados do formulário
    // Aqui você pode implementar a lógica para enviar os dados para a API, por exemplo
    console.log('Formulário enviado');
    handleCloseModal(); // Fecha o modal após submissão
  };

  const confirmDelete = (event: any) => {
    event.preventDefault();
    // Lógica para salvar os dados do formulário
    // Aqui você pode implementar a lógica para enviar os dados para a API, por exemplo
    console.log('Formulário deletado');
    handleCloseModal(); // Fecha o modal após submissão
  };

  const data = [
    { id: 1, nome: 'Kaio', idade: 25, dataNascimento: '1998/10/07' },
    { id: 2, nome: 'Clauder', idade: 37, dataNascimento: '1987/02/17' },
    { id: 3, nome: 'Ricardo', idade: 32, dataNascimento: '1992/06/15' },
];

const columnsStudents = [
    {
      name: 'Nome',
      cell: (row: any) => row.nome,
      sortable: true,
      wrap: true,
    },
    {
      name: 'Idade',
      cell: (row: any) => row.idade,
      sortable: true,
      wrap: true,
    },
    {
      name: 'Data Nascimento',
      selector: (row: any) => dayjs(row.dataNascimento).format('DD/MM/YYYY'),
      sortable: true,
    },
    {
      name: 'Ação',
      cell: (row: any) => (
        <>
            
        <Button variant="warning" size="sm" className="me-2" onClick={handleOpenModal}>
          Alterar
        </Button>
        <DeleteButtonConfirm onConfirmationAction={()=>confirmDelete(row)}/>
        
        </>
      ),
    },
  ];

    

  return (
    <>
    <div className="container mt-5">
          <DataTable columns={columnsStudents} data={data}/>  
              
    </div>
                
      {/* Botão para abrir o modal */}
      
        <Modal show = {showModal}
         onHide={handleCloseModal}
          size='lg' 
          centered = {true}>
                <form onSubmit={handleSubmit}>
            <ModalHeader><ModalTitle>Alterar Dados Estudante</ModalTitle></ModalHeader>
            <ModalBody>
            <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="nome" className="form-label">Nome</label>
                    <input type="text" className="form-control" id="nome"  />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="idade" className="form-label">Idade</label>
                    <input type="number" className="form-control" id="idade" min="1" minLength={1}  />
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="serie" className="form-label">Série</label>
                    <input type="number" className="form-control" id="serie" min="1" minLength={1} />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="notaMedia" className="form-label">Nota Média</label>
                    <input type="number" className="form-control" id="notaMedia" step="0.1" min="0" minLength={0} />
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="endereco" className="form-label">Endereço</label>
                    <input type="text" className="form-control" id="endereco"  />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="nomePai" className="form-label">Nome do Pai</label>
                    <input type="text" className="form-control" id="nomePai"  />
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="nomeMae" className="form-label">Nome da Mãe</label>
                    <input type="text" className="form-control" id="nomeMae"  />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="dataNascimento" className="form-label">Data de Nascimento</label>
                    <input type="date" className="form-control" id="dataNascimento"  />
                  </div>
                </div>

            </ModalBody>
    <ModalFooter>
    
    <button type="button" className="btn btn-secondary" onClick={handleCloseModal}>Close</button>
    <button type="submit" className="btn btn-primary">Salvar alterações</button>
    </ModalFooter>
    </form>
        </Modal>
      
    </>
  );
};

export default StudentList;
