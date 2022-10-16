import axios, { AxiosResponse } from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api/';
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
}

const Inventory = {
    list: () => requests.get('medicines'),
    details: (id: number) => requests.get(`medicines/${id}`)
}

const Cart = {
    get: () => requests.get('cart'),
    addItem: (medicineId: number, quantity = 1) => requests.post(`cart?medicineId=${medicineId}&quantity=${quantity}`, {}),
    removeItem: (medicineId: number, quantity = 1) => requests.delete(`cart?medicineId=${medicineId}&quantity=${quantity}`),
}

const Journal = {
    login: (values: any) => requests.post('journal/login', values),
    register: (values: any) => requests.post('journal/register', values),
    currentUser: () => requests.get('journal/currentUser'),
}

const agent = {
    Inventory,
    Cart,
    Journal
}

export default agent;
