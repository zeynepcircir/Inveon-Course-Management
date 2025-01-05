import { Carousel } from 'react-bootstrap';

const SliderComponent = () => {
  return (
    <Carousel style={{ maxWidth: '900px', maxHeight: '400px', margin: '0 auto' }}>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://images.pexels.com/photos/1181676/pexels-photo-1181676.jpeg?auto=compress&cs=tinysrgb&w=600"
          alt="First slide"
          style={{
            maxHeight: '400px',
            objectFit: 'cover',
            borderRadius: '15px',
            boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)',
          }}
        />
        <Carousel.Caption>
          <h3>First slide label</h3>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </Carousel.Caption>
      </Carousel.Item>

      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://images.pexels.com/photos/159220/printed-circuit-board-print-plate-via-macro-159220.jpeg?auto=compress&cs=tinysrgb&w=600"
          alt="Second slide"
          style={{
            maxHeight: '400px',
            objectFit: 'cover',
            borderRadius: '15px',
            boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)',
          }}
        />
        <Carousel.Caption>
          <h3>Second slide label</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </Carousel.Caption>
      </Carousel.Item>

      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://images.pexels.com/photos/3771045/pexels-photo-3771045.jpeg?auto=compress&cs=tinysrgb&w=600"
          alt="Third slide"
          style={{
            maxHeight: '400px',
            objectFit: 'cover',
            borderRadius: '15px',
            boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)',
          }}
        />
        <Carousel.Caption>
          <h3>Third slide label</h3>
          <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
        </Carousel.Caption>
      </Carousel.Item>

      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://images.pexels.com/photos/3862603/pexels-photo-3862603.jpeg?auto=compress&cs=tinysrgb&w=600"
          alt="Fourth slide"
          style={{
            maxHeight: '400px',
            objectFit: 'cover',
            borderRadius: '15px',
            boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)',
          }}
        />
        <Carousel.Caption>
          <h3>Fourth slide label</h3>
          <p>Donec sed odio dui. Nulla vitae elit libero, a pharetra augue.</p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
};

export default SliderComponent;
