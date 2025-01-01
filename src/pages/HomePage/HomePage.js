import React, { useState } from 'react';
import {
  Container,
  Row,
  Col,
  Card,
  CardBody,
  CardTitle,
  CardText,
  Button,
  Input,
  InputGroup,
  InputGroupText,
  Badge,
  Pagination,
  PaginationItem,
  PaginationLink
} from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import { FaShoppingCart, FaSearch } from 'react-icons/fa';
import courses from '../../data/courses';
import 'bootstrap/dist/css/bootstrap.min.css';
import SliderComponent from '../../components/Slider/Slider';

const HomePage = () => {
  const navigate = useNavigate();

  const [searchTerm, setSearchTerm] = useState('');
  const [selectedCategory, setSelectedCategory] = useState('All');
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 6; // Sayfa başına gösterilecek kurs sayısı

  // Sepete ekleme işlemi
  const handleAddToCart = (course) => {
    alert(`${course.title} has been added to your cart!`);
  };

  // Tüm kategorileri courses.js'den çek
  const categories = ['All', ...new Set(courses.map((course) => course.category))];

  // Arama ve filtreleme işlemi
  const filteredCourses = courses.filter((course) => {
    const matchesSearch = course.title.toLowerCase().includes(searchTerm.toLowerCase());
    const matchesCategory =
      selectedCategory === 'All' || course.category === selectedCategory;
    return matchesSearch && matchesCategory;
  });

  // Pagination işlemi
  const startIndex = (currentPage - 1) * itemsPerPage;
  const currentPageData = filteredCourses.slice(startIndex, startIndex + itemsPerPage);
  const totalPages = Math.ceil(filteredCourses.length / itemsPerPage);

  const handlePageChange = (page) => {
    setCurrentPage(page);
    window.scrollTo(0, 0); // Sayfa değişiminde yukarı kaydır
  };

  return (
    <Container className="py-5">
       <Container fluid className="mb-5">
      <SliderComponent />
    </Container>
      {/* Arama Çubuğu */}
      <div className="mb-4 text-center">
        <InputGroup style={{ maxWidth: '600px', margin: '0 auto' }}>
          <Input
            type="text"
            placeholder="Search for a course"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <InputGroupText>
            <FaSearch />
          </InputGroupText>
        </InputGroup>
      </div>

      {/* Kategoriler */}
      <div className="mb-4 text-center">
        {categories.map((category) => (
          <Badge
            key={category}
            color={selectedCategory === category ? 'primary' : 'secondary'}
            pill
            className="mx-1"
            onClick={() => {
              setSelectedCategory(category);
              setCurrentPage(1); // Kategori değiştiğinde ilk sayfaya dön
            }}
            style={{ cursor: 'pointer' }}
          >
            {category}
          </Badge>
        ))}
      </div>

      {/* Kurslar */}
      <Row className="gx-4 gy-5">
        {currentPageData.map((course) => (
          <Col md={4} key={course.id}>
            <Card className="shadow-sm">
              <img
                src={course.image}
                alt={course.title}
                className="card-img-top img-fluid rounded"
                style={{ maxHeight: '200px', objectFit: 'cover', borderBottom: '1px solid #ddd' }}
              />
              <CardBody>
                <CardTitle tag="h5" className="fw-bold">{course.title}</CardTitle>
                <CardText className="text-muted">
                  <strong>Category:</strong> {course.category}
                  <br />
                  <strong>Price:</strong> {course.price}
                  <br />
                  <strong>Chapters:</strong> {course.chapters}
                  <br />
                  <strong>Description:</strong> {course.description.slice(0, 50)}...
                </CardText>
                <div className="d-flex justify-content-between align-items-center">
                  <Button
                    color="primary"
                    onClick={() => navigate(`/course/${course.id}`)}
                  >
                    View Details
                  </Button>
                  <FaShoppingCart
                    size={20}
                    className="text-primary"
                    style={{ cursor: 'pointer' }}
                    onClick={() => handleAddToCart(course)}
                    title="Add to Cart"
                  />
                </div>
              </CardBody>
            </Card>
          </Col>
        ))}
      </Row>

      {/* Pagination */}
      <div className="mt-4 d-flex justify-content-center">
        <Pagination>
          <PaginationItem disabled={currentPage === 1}>
            <PaginationLink
              previous
              onClick={() => handlePageChange(currentPage - 1)}
            />
          </PaginationItem>
          {[...Array(totalPages)].map((_, index) => (
            <PaginationItem
              key={index}
              active={currentPage === index + 1}
            >
              <PaginationLink onClick={() => handlePageChange(index + 1)}>
                {index + 1}
              </PaginationLink>
            </PaginationItem>
          ))}
          <PaginationItem disabled={currentPage === totalPages}>
            <PaginationLink
              next
              onClick={() => handlePageChange(currentPage + 1)}
            />
          </PaginationItem>
        </Pagination>
      </div>
    </Container>
  );
};

export default HomePage;
