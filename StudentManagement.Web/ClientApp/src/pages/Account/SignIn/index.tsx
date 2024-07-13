import React from 'react';
import './styles.scss'; 
import '../../../styles/global.scss'; 




const SignIn = () => {
  const handleSubmit = (event: { preventDefault: () => void; }) => {
    event.preventDefault();
    
    console.log('Formulário enviado!');
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
                  
                  <input type="text" className="form-control form-control-lg" placeholder='Usuário' />
                  
                  </div>

                  <div className="form-outline mb-4">
                  
                    <input type="password"  className="form-control form-control-lg" placeholder='Senha'/>
                    
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

export default SignIn;
