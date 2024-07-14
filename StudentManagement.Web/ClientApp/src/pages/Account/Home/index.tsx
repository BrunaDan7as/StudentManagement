import React from 'react';
import './styles.scss'; 
import '../../../styles/global.scss'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate } from 'react-router-dom';
import { useUser } from '../../../context/UserContext';


const Home: React.FC = () => {
    const { user, logout } = useUser(); // Usar o contexto para obter o usuário e a função de logout
    const navigate = useNavigate();

    // Dados simulados para a tabela
    const data = [
        { id: 1, name: 'Kaio', quantity: 25, price: '07/10/1998' },
        { id: 2, name: 'Clauder', quantity: 37, price: '17/02/1987' },
        { id: 3, name: 'Ricardo', quantity: 32, price: '15/06/1992' },
    ];

    const handleLogout = () => {
        logout();
        navigate('/');
    };

    return (
        <div className='home-section'>
            <nav className="navbar navbar-expand-lg navbar-light bg-light shadow-lg">
                <div className="container-fluid d-flex justify-content-between align-items-center">
                    <span className="navbar-brand mb-0 h1">Logado como {user?.user}</span>
                    <div>
                        <button className="btn btn-success me-2" data-bs-toggle="modal" data-bs-target="#exampleModal3">Cadastrar Estudante</button>
                        <button onClick={handleLogout} className="btn btn-danger">Sair</button>
                    </div>
                </div>
            </nav>

            
            <div className="container mt-5">
                <div className="table-responsive"> 
                    <table className="table table-bordered table-hover shadow">
                        <thead className="table-dark">
                            <tr className='text-center'>
                                <th >ID</th>
                                <th>Nome</th>
                                <th>Idade</th>
                                <th>Data de Nascimento</th>
                                <th>Ação</th>
                            </tr>
                        </thead>
                        <tbody className='text-center'>
                            {data.map(item => (
                                <tr key={item.id}>
                                    <td className="col-md-2">{item.id}</td>
                                    <td className="col-md-2">{item.name}</td>
                                    <td className="col-md-2">{item.quantity}</td>
                                    <td className="col-md-2">{item.price}</td>
                                    <td className="col-md-2">
                                            <button  type="button" className="btn btn-sm  btn-warning me-2" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                    Alterar
                                </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
                            
                <div className="modal fade" id="exampleModal" aria-labelledby="exampleModalLabel" aria-hidden="true" >
                    <div className="modal-dialog">
                        <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="exampleModalLabel">Alterar Dados Estudante</h1>
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
                                <button type="button" className="btn btn-danger me-auto" data-bs-toggle="modal" data-bs-target="#exampleModal2">Excluir</button>
                                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                <button type="button" className="btn btn-primary">Salvar Alterações</button>
                            </div>                
                        </div>
                    </div>
                </div>
                <div className="modal fade" id="exampleModal2" aria-labelledby="exampleModalLabel2" aria-hidden="true">
  <div className="modal-dialog">
    <div className="modal-content">
      <div className="modal-header">
        <h1 className="modal-title fs-5" id="exampleModalLabel">Exclusão</h1>
        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div className="modal-body">
        Tem certeza que deseja excluir o estudante?
      </div>
      <div className="modal-footer">
        <button type="button" className="btn btn-danger" data-bs-dismiss="modal">Não</button>
        <button type="button" className="btn btn-success">Sim</button>
      </div>
    </div>
  </div>
</div>
    </div>

        
    );
};

export default Home;
