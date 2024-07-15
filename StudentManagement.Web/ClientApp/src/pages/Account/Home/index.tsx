import React from 'react';
import './styles.scss'; 
import '../../../styles/global.scss'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate } from 'react-router-dom';
import { useUser } from '../../../context/UserContext';
import StudentForm from '../../../components/StudentForm';
import StudentList from '../../../components/StudentList';


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
                        <StudentForm/>
                        <button onClick={handleLogout} className="btn btn-danger">Sair</button>
                    </div>
                </div>
            </nav>

            <StudentList/>

            
          </div>

        
    );
};

export default Home;
