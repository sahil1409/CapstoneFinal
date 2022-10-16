import Inventory from "./features/inventory/Inventory";
import Navbar from "./Navbar";
import { Container } from "@mui/system";
import { Route, Routes } from "react-router-dom";
import HomePage from "./features/home/HomePage";
import MedicineDetails from "./features/inventory/MedicineDetails";
import CartPage from "./features/cart/CartPage";
import { useStoreContext } from "./Context";
import { useEffect } from "react";
import { getCookie } from "./util";
import agent from "./agent";
import CheckoutPage from "./features/checkout/CheckoutPage";
import Register from "./features/journal/Register";
import Login from "./features/journal/Login";

function App() {

  const {setCart} = useStoreContext();

  useEffect(() => {
    const buyerId = getCookie('buyerId')
    if (buyerId) {
      agent.Cart.get()
        .then(cart => setCart(cart))
        .catch(error => console.log(error));
    }
  }, [setCart])

  return (
    <>
      <Navbar />
      <Container>
        <Routes>
          <Route path="/" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route path="/homepage" element={<HomePage />} />
          <Route path="/inventory" element={<Inventory/>} />
          <Route path="/inventory/:id" element={<MedicineDetails/>} />
          <Route path="/cart" element={<CartPage />} />
          <Route path='/checkout' element={<CheckoutPage />} />
        </Routes>
      </Container>
    </>
  )
}

export default App;
