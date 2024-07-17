import { BrowserRouter as Router, Navigate, Route, Routes } from 'react-router-dom';
import 'react-toastify/dist/ReactToastify.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import SignIn from './pages/Account/SignIn';
import Home from './pages/Account/Home';
import { ToastContainer } from 'react-toastify';
import { UserProvider, useUser } from './context/UserContext';
import { useEffect, useState } from 'react';

const ProtectedRoute = ({ isPrivate }: { isPrivate?: boolean }) => {
  const { user } = useUser();
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    setTimeout(() => {
      setLoading(false);
    }, 100);
  }, [])
  if (loading) {
    return <div className='text-center'></div>;
  }
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

          <Route path="/" element={<ProtectedRoute />} />

          <Route path="/home" element={<ProtectedRoute isPrivate />} />

        </Routes>
      </Router>
      <ToastContainer />
    </UserProvider>
  );
}

export default App;
