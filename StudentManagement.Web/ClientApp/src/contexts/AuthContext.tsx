// firebase-config.js
import { initializeApp } from "firebase/app";
import { getAuth, createUserWithEmailAndPassword, signInWithEmailAndPassword, UserCredential } from "firebase/auth";

const firebaseConfig = {
  apiKey: "API_KEY",
  authDomain: "PROJECT_ID.firebaseapp.com",
  projectId: "PROJECT_ID",
  storageBucket: "PROJECT_ID.appspot.com",
  messagingSenderId: "SENDER_ID",
  appId: "APP_ID",
};

const app = initializeApp(firebaseConfig);
const auth = getAuth(app);

type RegisterUserType = (email: string, password: string) => Promise<UserCredential>;
type LoginUserType = (email: string, password: string) => Promise<UserCredential>;

const registerUser: RegisterUserType = (email, password) => {
    return createUserWithEmailAndPassword(auth, email, password)
      .then((userCredential) => {
        // Usuário registrado com sucesso
        const user = userCredential.user;
        console.log("User registered:", user);
        return userCredential;
      })
      .catch((error) => {
        // Erro ao registrar o usuário
        console.error("Error registering user:", error);
        throw error; // Você pode tratar o erro de outra forma, se preferir
      });
  };
  
  // Função para login de um usuário existente
  const loginUser: LoginUserType = (email, password) => {
    return signInWithEmailAndPassword(auth, email, password)
      .then((userCredential) => {
        // Usuário logado com sucesso
        const user = userCredential.user;
        console.log("User logged in:", user);
        return userCredential;
      })
      .catch((error) => {
        // Erro ao logar o usuário
        console.error("Error logging in user:", error);
        throw error; // Você pode tratar o erro de outra forma, se preferir
      });
  };
  
  export { app, registerUser, loginUser };
