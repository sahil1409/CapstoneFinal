import 'bootstrap/dist/css/bootstrap.min.css';

import { Carousel } from 'react-bootstrap';
export default function HomePage() {
    return (
        <Carousel>
            <Carousel.Item>
                <img
                    className="d-block w-100"
                    src="https://i.ibb.co/HG8QDgc/1665652096862.jpg"
                    alt="First slide"
                />
            </Carousel.Item>
            <Carousel.Item>
                <img
                    className="d-block w-100"
                    src="https://i.ibb.co/bRR0p9k/2.png"
                    alt="Second slide"
                />
            </Carousel.Item>
        </Carousel>
    )
}