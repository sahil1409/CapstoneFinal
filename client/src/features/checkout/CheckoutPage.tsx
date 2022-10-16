import { Divider, Typography } from "@mui/material";
import { useStoreContext } from "../../Context";

export default function CheckoutPage() {

    const { cart } = useStoreContext();
    const total = cart?.items.reduce((sum, item) => sum + (item.quantity * item.price), 0) ?? 0;
    if (!cart) return <Typography variant='h3'>Your cart is empty</Typography>
    
    return (
        <div className="container mt-5 mb-5">
            <div className="row d-flex justify-content-center mt-1">
                <div className="col-md-8">
                    <div className="card">

                        <div className="invoice p-5">
                            <img alt="logo" style={{ display: "inline" }} className="text-left logo p-2" src="https://thumbs.dreamstime.com/b/plus-195775898.jpg" width="150" />
                            <h1 style={{ display: "inline" }}>Order Confirmed!</h1>

                            <Divider sx={{ borderBottomWidth: 5, bgcolor: "black" }} />

                            <div className="product border-bottom table-responsive">
                                <table className="table table-borderless">
                                    <tbody>
                                        <tr>
                                            <th style={{ width: "10%" }}></th>
                                            <th style={{ width: "20%" }}>
                                                <h5>Medicines</h5>
                                            </th>
                                            <th style={{ width: "47%" }}>
                                            </th>
                                            <th style={{ width: "23%" }}>
                                                <h5>SubTotal</h5>
                                            </th>
                                        </tr>
                                    </tbody>
                                </table>
                                <table className="table table-borderless">
                                    <tbody>
                                        {cart.items.map(item => (
                                            <tr>
                                                <td width="20%">
                                                    <img alt={item.name} src={item.image} width="90" />
                                                </td>
                                                <td width="60%">
                                                    <span className="font-weight-bold"><b>{item.name}</b></span>
                                                    <div className="product-qty">
                                                        <span className="d-block">Quantity: {item.quantity}</span>
                                                        <span className="d-block">Price: ₹{item.price}</span>
                                                    </div>
                                                </td>
                                                <td width="20%">
                                                    <div className="text-right">
                                                        <span className="font-weight-bold">₹{item.price * item.quantity}</span>
                                                    </div>
                                                </td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>

                            <div className="row d-flex justify-content-end">
                                <div className="col-md-5">
                                    <table className="table table-borderless">
                                        <tbody className="totals">
                                            <tr>
                                                <td>
                                                    <div className="text-left">
                                                        <span className="text-muted">Subtotal</span>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div className="text-right">
                                                        <span>₹{total}</span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div className="text-left">
                                                        <span className="text-muted">Shipping Fee</span>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div className="text-right">
                                                        <span>₹50</span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr className="border-top border-bottom">
                                                <td>
                                                    <div className="text-left">
                                                        <span className="font-weight-bold">Total</span>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div className="text-right">
                                                        <span className="font-weight-bold">₹{total + 50}</span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                            <p>You order has been confirmed and will be shipped in next two days!</p>
                            <p className="font-weight-bold mb-0">Thanks for shopping with us!</p>
                            <span><b>ABC Healthcare</b></span>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}