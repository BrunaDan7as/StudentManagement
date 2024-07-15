import React, { useState } from 'react';
import { ModalBody, ModalFooter, ModalHeader, ModalTitle } from 'react-bootstrap';
import Modal from 'react-bootstrap/Modal';
const CadastroModal: React.FC = () => {
  const [showModal, setShowModal] = useState(false);

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

  return (
    <>
      {/* Botão para abrir o modal */}
      <button type="button" className="btn btn-primary me-2" onClick={handleOpenModal}>
        Cadastrar Estudante
      </button>
        <Modal show = {showModal}
         onHide={handleCloseModal}
          size='lg' 
          centered = {true}>
                <form onSubmit={handleSubmit}>
            <ModalHeader><ModalTitle>Cadastrar Estudante</ModalTitle></ModalHeader>
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
    <button type="submit" className="btn btn-success">Cadastrar</button>
    </ModalFooter>
    </form>
        </Modal>
      {/* <div className="modal fade" id="exampleModal4" aria-labelledby="exampleModalLabel" aria-hidden="true" >
                    <div className="modal-dialog">
                        <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="exampleModalLabel">Cadastrar Estudante</h1>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                        <form>
                <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="nome" className="form-label">Nome</label>
                    <input type="text" className="form-control" id="nome" />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="idade" className="form-label">Idade</label>
                    <input type="number" className="form-control" id="idade" />
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="serie" className="form-label">Série</label>
                    <input type="text" className="form-control" id="serie" />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="notaMedia" className="form-label">Nota Média</label>
                    <input type="text" className="form-control" id="notaMedia" />
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="endereco" className="form-label">Endereço</label>
                    <input type="text" className="form-control" id="endereco" />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="nomePai" className="form-label">Nome do Pai</label>
                    <input type="text" className="form-control" id="nomePai" />
                  </div>
                </div>
                <div className="row">
                  <div className="col-md-6 mb-3">
                    <label htmlFor="nomeMae" className="form-label">Nome da Mãe</label>
                    <input type="text" className="form-control" id="nomeMae" />
                  </div>
                  <div className="col-md-6 mb-3">
                    <label htmlFor="dataNascimento" className="form-label">Data de Nascimento</label>
                    <input type="date" className="form-control" id="dataNascimento" />
                  </div>
                </div>
              </form>
            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                <button type="button" className="btn btn-primary">Cadastrar</button>
                            </div>                
                        </div>
                    </div>
                </div> */}
    </>
  );
};

export default CadastroModal;
