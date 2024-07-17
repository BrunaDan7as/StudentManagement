import { AxiosResponse } from "axios";
import { authenticationRequest } from "../../models/userModal";
import api from "../api";

const authentication = async (request: authenticationRequest): Promise<AxiosResponse> => {
    try {
        const response = await api.post('/auth/login', request);
        return response;
    } catch (error) {
        console.error('Erro durante o login:', error);
        throw error;
    }
};
 
export { authentication };