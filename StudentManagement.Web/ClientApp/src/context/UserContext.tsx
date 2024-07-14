// UserContext.tsx
import React, { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { userModel } from '../models/userModal';


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
    }
  };

  const login = (userData: userModel) => {
    setUser(userData);
    if (userData !== undefined) {
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
