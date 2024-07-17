import { AxiosResponse } from "axios";
import { studentModel } from "../../models/studentModel";
import api from "../api";

const API_URL = '/students';

const studentService = {
    getAllStudents: async (): Promise<AxiosResponse<studentModel[]>> => {
        const response = await api.get<studentModel[]>(API_URL);
        return response;
    },
 
    getStudentById: async (id: number): Promise<AxiosResponse<studentModel>> => {
        const response = await api.get<studentModel>(`${API_URL}/${id}`);
        return response;
    },

    createStudent: async (student: studentModel): Promise<AxiosResponse<studentModel>> => {
        const response = await api.post<studentModel>(API_URL, student);
        return response;
    },

    updateStudent: async (id: number, student: studentModel): Promise<AxiosResponse<studentModel>> => {
        const response = await api.put<studentModel>(`${API_URL}/${id}`, student);
        return response;
    },

    deleteStudent: async (id: number): Promise<AxiosResponse<void>> => {
        const response = await api.delete<void>(`${API_URL}/${id}`);
        return response;
    }
};

export default studentService;