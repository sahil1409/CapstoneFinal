export interface CartItem {
    medicineId: number;
    name: string;
    price: number;
    image: string;
    seller: string;
    description: string;
    quantity: number;
    category: string;
}

export interface Cart {
    id: number;
    buyerId: string;
    items: CartItem[];
}



