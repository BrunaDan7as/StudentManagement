import { ErrorMessage, Formik } from 'formik';
import React, { useState } from 'react';
import { ModalBody, ModalFooter, ModalHeader, ModalTitle } from 'react-bootstrap';
import Modal from 'react-bootstrap/Modal';
import { studentModel } from '../../models/studentModel';
import { toast } from 'react-toastify';
import * as Yup from 'yup';
import studentService from '../../services/student/studentService';

type Props = {
  AtualizaData: () => void;
};
const CadastroModal: React.FC<Props> = ({ AtualizaData }) => {
  const [showModal, setShowModal] = useState(false);

  const handleCloseModal = () => {
    setShowModal(false);
  };

  const handleOpenModal = () => {
    setShowModal(true);
  };

  const handleSubmit = (event: studentModel) => {
    studentService.createStudent(event)
      .then((response: any) => {
        AtualizaData()
        toast.success('Estudante cadastrado com sucesso!');
      })
      .catch((err: any) => {
        console.error(err);
        toast.error('Dados inválidos.', {
          className: 'toast-error',
        });
      });

    handleCloseModal();
  };
  const validationSchema = Yup.object().shape({
    nome: Yup.string().required('O nome é obrigatório'),
    idade: Yup.number().positive('A idade deve ser um número positivo').integer().required('A idade é obrigatória'),
    serie: Yup.number().positive('A série deve ser um número positivo').integer().required('A série é obrigatória'),
    notaMedia: Yup.number().min(1, 'A nota média não pode ser menor que 1').max(10, 'A nota média não pode ser maior que 10').required('A nota média é obrigatória'),
    endereco: Yup.string().required('O endereço é obrigatório'),
    nomePai: Yup.string().required('O nome do pai é obrigatório'),
    nomeMae: Yup.string().required('O nome da mãe é obrigatório'),
    dataNascimento: Yup.date()
      .required('A data de nascimento é obrigatória')
      .max(new Date(), 'A data de nascimento não pode ser no futuro'),
  });
  return (
    <>

      <button type="button" className="btn btn-primary me-2" onClick={handleOpenModal}>
        Cadastrar Estudante
      </button>
      <Modal show={showModal}
        onHide={handleCloseModal}
        size='lg'
        centered={true}>
        <Formik
          initialValues={{} as studentModel}
          onSubmit={(Student: studentModel) => {
            try {
              handleSubmit(
                Student
              );

            } catch (err) {
              toast.error("Ocorreu um erro inesperado", {
                className: "toast-error",
              });
            }
          }}
          validationSchema={validationSchema}
        >
          {(props) => {
            const {
              values,
              touched,
              errors,
              dirty,
              isSubmitting,
              isValid,
              handleChange,
              handleBlur,
              handleSubmit,
            } = props;
            return (
              <form onSubmit={handleSubmit}>
                <ModalHeader><ModalTitle>Alterar Dados Estudante</ModalTitle></ModalHeader>
                <ModalBody>
                  <div className="row">
                    <div className="col-md-6 mb-3">
                      <label htmlFor="nome" className="form-label">Nome</label>
                      <input type="text" className={
                        errors.nome && touched.nome
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="nome"
                        defaultValue={values.nome}
                        onChange={handleChange}
                        title={errors.nome}
                        onBlur={handleBlur} />
                      <ErrorMessage name="nome" component="div" className="invalid-feedback" />
                    </div>
                    <div className="col-md-6 mb-3">
                      <label htmlFor="idade" className="form-label">Idade</label>
                      <input type="number" className={
                        errors.idade && touched.idade
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="idade" min="1" minLength={1} defaultValue={values.idade} onChange={handleChange} title={errors.idade} onBlur={handleBlur} />
                      <ErrorMessage name="idade" component="div" className="invalid-feedback" />
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6 mb-3">
                      <label htmlFor="serie" className="form-label">Série</label>
                      <input type="number" className={
                        errors.serie && touched.serie
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="serie" min="1" minLength={1} defaultValue={values.serie} onChange={handleChange} title={errors.serie} onBlur={handleBlur} />
                      <ErrorMessage name="serie" component="div" className="invalid-feedback" />
                    </div>
                    <div className="col-md-6 mb-3">
                      <label htmlFor="notaMedia" className="form-label">Nota Média</label>
                      <input type="number" className={
                        errors.notaMedia && touched.notaMedia
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="notaMedia" step="0.1" min="0" minLength={0} defaultValue={values.notaMedia} onChange={handleChange} title={errors.notaMedia} onBlur={handleBlur} />
                      <ErrorMessage name="notaMedia" component="div" className="invalid-feedback" />
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6 mb-3">
                      <label htmlFor="endereco" className="form-label">Endereço</label>
                      <input type="text" className={
                        errors.endereco && touched.endereco
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="endereco" defaultValue={values.endereco} onChange={handleChange} title={errors.endereco} onBlur={handleBlur} />
                      <ErrorMessage name="endereco" component="div" className="invalid-feedback" />
                    </div>
                    <div className="col-md-6 mb-3">
                      <label htmlFor="nomePai" className="form-label">Nome do Pai</label>
                      <input type="text" className={
                        errors.nomePai && touched.nomePai
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="nomePai" defaultValue={values.nomePai} onChange={handleChange} title={errors.nomePai} onBlur={handleBlur} />
                      <ErrorMessage name="nomePai" component="div" className="invalid-feedback" />
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6 mb-3">
                      <label htmlFor="nomeMae" className="form-label">Nome da Mãe</label>
                      <input type="text" className={
                        errors.nomeMae && touched.nomeMae
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="nomeMae" defaultValue={values.nomeMae} onChange={handleChange} title={errors.nomeMae} onBlur={handleBlur} />
                      <ErrorMessage name="nomeMae" component="div" className="invalid-feedback" />
                    </div>
                    <div className="col-md-6 mb-3">
                      <label htmlFor="dataNascimento" className="form-label">Data de Nascimento</label>
                      <input type="date" className={
                        errors.dataNascimento && touched.dataNascimento
                          ? "form-control is-invalid "
                          : "form-control"
                      } id="dataNascimento" defaultValue={values.dataNascimento} onChange={handleChange} title={errors.dataNascimento} onBlur={handleBlur} />
                      <ErrorMessage name="dataNascimento" component="div" className="invalid-feedback" />
                    </div>
                  </div>

                </ModalBody>
                <ModalFooter>

                  <button type="button" className="btn btn-secondary" onClick={handleCloseModal}>Close</button>
                  <button type="submit" className="btn btn-primary" disabled={!dirty || isSubmitting || !isValid}>Salvar alterações</button>
                </ModalFooter>
              </form>
            );
          }}
        </Formik>
      </Modal>
    </>
  );
};

export default CadastroModal;
