import { BrowserRouter, Routes } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

// import { Toaster } from "react-hot-toast";


import { useState } from 'react';
import { LoadingContextProvider } from "./contexts/LoadingContext";


import SignIn from './pages/Account/SignIn';
function App() {

    const contextClass = {
        success: "bg-blue-600",
        error: "bg-red-600",
        info: "bg-gray-600",
        warning: "bg-orange-400",
        default: "bg-indigo-600",
        dark: "bg-white-600 font-gray-300",
    };


    return (
        <>
            <SignIn/>
        </>

    );
}

export default App;
