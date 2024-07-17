import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { authenticationRequest, userModel } from "../../models/userModal";
import { useUser } from "../../context/UserContext";

import { toast } from "react-toastify";
import { authentication } from "../../services/user/userService";

const Login: React.FC = () => {
  const [user, setUser] = useState('');
  const [password, setPassword] = useState('');
  const { login } = useUser(); 
  const navigate = useNavigate();

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();

    const request ={ password : password , username : user} as authenticationRequest
    
        authentication(request)
      .then((response: any) => {
        const userData: userModel = {
          user: response.data.username,
          token: response.data.token,
        };
        login(userData);
        navigate('/home'); 
        toast.success('Logado com sucesso!');
      })
      .catch((err: any) => {
        console.error(err);
 
        toast.error('Dados não autorizados.', {
          className: 'toast-error',
        });

        const { errors } = err.response?.data || {};
        if (errors !== undefined) {
          Object.entries(errors).forEach(([key, value]) => {
            setPassword('');
            setUser('');
            toast.error(`${value}`, {
              className: 'toast-error',
            });
          });
        }
      });
   
  };
  

    return (
      <section className="sign-in-section">
        <div className="container py-5 h-100">
          <div className="row d-flex justify-content-center align-items-center h-100">
            <div className="col-12 col-md-8 col-lg-6 col-xl-5">
              <div className="card card-custom shadow-2-strong">
                <div className="card-body p-5 text-center">
  
                  <h3 className="mb-5">Sign in</h3>
  
                  <form onSubmit={handleSubmit}>
                    <div className="form-outline mb-4">
                    
                    <input type="text"  onChange={(e) => setUser(e.target.value)} className="form-control form-control-lg" placeholder='Usuário' />
                    
                    </div>
  
                    <div className="form-outline mb-4">
                    
                      <input type="password" onChange={(e) => setPassword(e.target.value)}  className="form-control form-control-lg" placeholder='Senha'/>
                      
                    </div>
  
                    
  
                    <button className="btn btn-primary btn-lg btn-block" type="submit">Login</button>
  
                   
                  </form>
  
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    );
}
export default Login;