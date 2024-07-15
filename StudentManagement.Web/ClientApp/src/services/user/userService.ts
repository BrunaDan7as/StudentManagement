import { authenticationRequest } from "../../models/userModal";
import api from "../api";

const userService = {

    login: async function (request:authenticationRequest) {
        const response = await api.post(`/user/login`,request)
        return response;
    },
}
export default userService