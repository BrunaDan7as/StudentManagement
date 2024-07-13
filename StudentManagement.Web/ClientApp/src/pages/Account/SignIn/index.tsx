import './styles.scss'; 
import '../../../styles/global.scss'; 
import { userModel } from '../../../models/userModal';
import Login from '../../../components/Login';




const SignIn = ({ onLogin }: { onLogin: (userData: userModel) => void }) => {

  return (
    <Login onLogin={onLogin}/>
  );
}

export default SignIn;
