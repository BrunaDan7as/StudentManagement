import React, { useEffect, useState } from 'react';
import './styles.scss';
import '../../../styles/global.scss';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate } from 'react-router-dom';
import { useUser } from '../../../context/UserContext';
import StudentForm from '../../../components/StudentForm';
import StudentList from '../../../components/StudentList';
import studentService from '../../../services/student/studentService';
import { toast } from 'react-toastify';
import { studentModel } from '../../../models/studentModel';


const Home: React.FC = () => {
  const { user, logout } = useUser();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/');
  };
  const [listStudent, setListStudent] = useState([] as studentModel[]);

  function AtualizaData() {
    studentService
      .getAllStudents()
      .then((response: any) => {
        const students = response.data;
        setListStudent(students);
      })
      .catch((err) => {
        if (err.response) {
          toast.error(err.response.data.message, {
            className: "error",
          });
        }
      });
  }
  useEffect(() => {
    AtualizaData()
  }, []);
  return (
    <div className='home-section'>
      <nav className="navbar navbar-expand-lg navbar-light bg-light shadow-lg">
        <div className="container-fluid d-flex justify-content-between align-items-center">
          <span className="navbar-brand mb-0 h1">Logado como {user?.user}</span>
          <div>
            <StudentForm AtualizaData={AtualizaData} />
            <button onClick={handleLogout} className="btn btn-danger">Sair</button>
          </div>
        </div>
      </nav>

      <StudentList AtualizaData={AtualizaData} Data={listStudent} />

    </div>

  );
};

export default Home;
