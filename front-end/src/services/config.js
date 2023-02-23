import axios from 'axios';
import utilStorage from '../util/storage';

export const http = axios.create({
    baseURL: 'https://localhost:7178/api/'
});

http.interceptors.request.use((config) => {
    let token = utilStorage.obterTokenNaStorage();
    config.headers.Authorization = `Bearer ${token}`
    return config;
})