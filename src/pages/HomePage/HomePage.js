import React, { useState, useEffect } from 'react';
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
import 'bootstrap/dist/css/bootstrap.min.css';
import SliderComponent from '../../components/Slider/Slider';
import axiosInstance from '../../api/axios'; 
import API_ENDPOINTS from '../../api/endpoints'; 

const HomePage = () => {
  const navigate = useNavigate();

  const [searchTerm, setSearchTerm] = useState('');
  const [selectedCategory, setSelectedCategory] = useState('All');
  const [currentPage, setCurrentPage] = useState(1);
  const [courses, setCourses] = useState([]);
  const [categories, setCategories] = useState([]);
  const itemsPerPage = 6; 

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await axiosInstance.get(API_ENDPOINTS.category.getAll);
        setCategories(['All', ...response.data.data.map(category => category.name)]); 
      } catch (error) {
        console.error('Error fetching courses:', error);
      }
    };
    
    const fetchCourses = async () => {
      try {
        const response = await axiosInstance.get(API_ENDPOINTS.course.getAll);
        console.log('response.data.data :>> ', response.data.data);
        setCourses(response.data.data); 
      } catch (error) {
        console.error('Error fetching courses:', error);
      }
    };

    fetchCategories();
    fetchCourses();
  }, []);

  const handleAddToCart = (course) => {
    alert(`${course.title} has been added to your cart!`);
  };

  const filteredCourses = courses.filter((course) => {
    const matchesSearch = course.title.toLowerCase().includes(searchTerm.toLowerCase());
    const matchesCategory =
      selectedCategory === 'All' || course.categoryName === selectedCategory;
    return matchesSearch && matchesCategory;
  });

  const startIndex = (currentPage - 1) * itemsPerPage;
  const currentPageData = filteredCourses.slice(startIndex, startIndex + itemsPerPage);
  const totalPages = Math.ceil(filteredCourses.length / itemsPerPage);

  const handlePageChange = (page) => {
    setCurrentPage(page);
    window.scrollTo(0, 0); 
  };

  return (
    <Container className="py-5">
       <Container fluid className="mb-5">
        <SliderComponent/>
      </Container>
      <div className="mb-4 text-center">
      <InputGroup
        style={{
          maxWidth: '600px',
          margin: '0 auto',
          borderRadius: '20px', 
          overflow: 'hidden', 
          boxShadow: '0 2px 5px rgba(0, 0, 0, 0.1)', 
        }}
      >
        <Input
          type="text"
          placeholder="Search for a course"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          style={{
            border: 'none',
            borderRadius: '0', 
            boxShadow: 'none', 
          }}
        />
        <InputGroupText
          style={{
            backgroundColor: '#007bff', 
            color: '#fff', 
            border: 'none',
            borderRadius: '0', 
            cursor: 'pointer',
          }}
        >
          <FaSearch />
        </InputGroupText>
      </InputGroup>
    </div>
      <div className="mb-4 text-center">
        {categories.map((category) => (
          <Badge
            key={category}
            color={selectedCategory === category ? 'primary' : 'secondary'}
            pill
            className="mx-1"
            onClick={() => {
              setSelectedCategory(category);
              setCurrentPage(1); 
            }}
            style={{ cursor: 'pointer' }}
          >
            {category}
          </Badge>
        ))}
      </div>

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
                  <strong>Category:</strong> {course.categoryName}
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
