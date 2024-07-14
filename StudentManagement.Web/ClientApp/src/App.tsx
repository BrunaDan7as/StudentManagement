import { BrowserRouter as Router, Navigate, Route, Routes } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import SignIn from './pages/Account/SignIn';
import Home from './pages/Account/Home';
import { UserProvider, useUser } from './context/UserContext'; // ajuste o caminho conforme necessário

const ProtectedRoute = ({ isPrivate }: { isPrivate?: boolean }) => {
  const { user } = useUser();
  if (isPrivate && !user?.token) {
    return <Navigate to="/" />;
  }
  return user?.token ? <Home /> : <SignIn />;
};

function App() {
  return (
    <UserProvider>
      <Router>
        <Routes>
          {/* Rota de login (pública) */}
          <Route path="/" element={<ProtectedRoute />} />

          {/* Rota privada - acessível apenas após o login */}
          <Route path="/home" element={<ProtectedRoute isPrivate />} />

          {/* Rota de página não encontrada */}
          {/* <Route path="*" element={<NotFound />} /> */}
        </Routes>
      </Router>
    </UserProvider>
  );
}

export default App;
