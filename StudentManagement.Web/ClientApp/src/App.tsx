import { BrowserRouter as Router, Navigate, Route,  Routes } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

// import { Toaster } from "react-hot-toast";


import { useEffect, useState } from 'react';



import SignIn from './pages/Account/SignIn';
import Home from './pages/Account/Home';
import { userModel } from './models/userModal';
function App() {
  const [user, setUser] = useState<userModel | null>(null);
  
  useEffect(() => {
    verify();
    }, []);

    const verify = () =>{
      const token = localStorage.getItem('@Ubc:token');
      const users = localStorage.getItem('@Ubc:user');
      if(token !== null && users !==null){
       setUser({user:users,token:token})
      }
    }

    const login = (userData:userModel) => {
      setUser(userData);
      if(userData !== undefined){
        localStorage.setItem('@Ubc:token', userData?.token);
        localStorage.setItem('@Ubc:user', userData.user);
      }
      
    };
    const logout = () => {
      localStorage.removeItem('@Ubc:token');
      localStorage.removeItem('@Ubc:user');
      setUser(null);
    };

    return (
        <>
      <Router>
      <Routes>

        {/* Rota de login (pública) */}
        <Route path="/" element={user?.token == null ? <SignIn onLogin={login} />: <Home user={user} onLogout={logout} /> } />

        {/* Rota privada - acessível apenas após o login */}
        <Route
          path="/home"
          element={user?.token != null ? <Home user={user} onLogout={logout} /> : <Navigate to="/" />}
        />

        {/* Rota de página não encontrada */}
        {/* <Route path="*" element={<NotFound />} /> */}
      </Routes>
    </Router>
        </>

    );
}

export default App;
