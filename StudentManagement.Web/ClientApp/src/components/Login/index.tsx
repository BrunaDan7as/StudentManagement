import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { userModel } from "../../models/userModal";

const Login = ({ onLogin }: { onLogin: (userData: userModel) => void }) => {
    const [user, setUser] = useState('');
    const [password, setPassword] = useState('');
  
    const navigate = useNavigate()
    const handleSubmit = (event: { preventDefault: () => void; }) => {
   
      event.preventDefault();
  
      // const request = {
      //   user: user,
      //   toke: password,
      // } as userModel;
  
      const userData: userModel = {
        user: user,
        token: password,
      };
      onLogin(userData)
      navigate('/home'); 
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