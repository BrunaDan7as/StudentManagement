// UserContext.tsx
import { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { userModel } from '../models/userModal';
import api from '../services/api';


interface UserContextProps {
  user: userModel | null;
  login: (userData: userModel) => void;
  logout: () => void;
}

const UserContext = createContext<UserContextProps | undefined>(undefined);

export const UserProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<userModel | null>(null);

  useEffect(() => {
    verify();
  }, []);

  const verify = () => {
    const token = localStorage.getItem('@Ubc:token');
    const users = localStorage.getItem('@Ubc:user');
    if (token !== null && users !== null) {
      setUser({ user: users, token: token });
      api.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    }
  };

  const login = (userData: userModel) => {
    setUser(userData);
    if (userData !== undefined) {
      localStorage.setItem('@Ubc:token', userData?.token);
      localStorage.setItem('@Ubc:user', userData.user);
      api.defaults.headers.common['Authorization'] = `Bearer ${userData?.token}`;

    }

  };

  const logout = () => {
    localStorage.removeItem('@Ubc:token');
    localStorage.removeItem('@Ubc:user');
    setUser(null);
  };

  return (
    <UserContext.Provider value={{ user, login, logout }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUser = (): UserContextProps => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error('useUser must be used within a UserProvider');
  }
  return context;
};
