import React, { useState } from 'react';
import {
  Container,
  Button,
  Table,
  Input,
  Pagination,
  PaginationItem,
  PaginationLink
} from 'reactstrap';
import { useNavigate } from 'react-router-dom';
import alertify from 'alertifyjs';
import courses from '../../data/courses'; // Veriyi courses.js'den al
import 'bootstrap/dist/css/bootstrap.min.css';

const TeacherPage = () => {
  const navigate = useNavigate();

  const [filteredCourses, setFilteredCourses] = useState(courses); // Filtrelenmiş kurslar
  const [sortConfig, setSortConfig] = useState({ key: '', direction: 'asc' });
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 5; // Her sayfada gösterilecek eleman sayısı

  // Edit işlemi
  const handleEdit = (id) => {
    navigate(`/teacher/edit/${id}`);
  };

  // Delete işlemi
  const handleDelete = (id) => {
    alertify
      .confirm(
        'Delete Course',
        `Are you sure you want to delete the course with ID: ${id}?`,
        () => {
          alertify.success('Course deleted successfully!');
        },
        () => {
          alertify.error('Delete operation canceled.');
        }
      )
      .set('labels', { ok: 'Yes', cancel: 'No' })
      .set('movable', false)
      .set('position', 'top-right');
  };

  // Add New Course
  const handleAddCourse = () => {
    navigate('/teacher/add');
  };

  // Filtreleme
  const handleFilter = (key, value) => {
    const filtered = courses.filter((course) =>
      course[key].toLowerCase().includes(value.toLowerCase())
    );
    setFilteredCourses(filtered);
    setCurrentPage(1); // Filtrelemeden sonra ilk sayfaya dön
  };

  // Sıralama
  const handleSort = (key) => {
    let direction = 'asc';
    if (sortConfig.key === key && sortConfig.direction === 'asc') {
      direction = 'desc';
    }
    const sortedCourses = [...filteredCourses].sort((a, b) => {
      if (a[key] < b[key]) return direction === 'asc' ? -1 : 1;
      if (a[key] > b[key]) return direction === 'asc' ? 1 : -1;
      return 0;
    });
    setFilteredCourses(sortedCourses);
    setSortConfig({ key, direction });
  };

  // Sayfalama
  const startIndex = (currentPage - 1) * itemsPerPage;
  const currentPageData = filteredCourses.slice(startIndex, startIndex + itemsPerPage);
  const totalPages = Math.ceil(filteredCourses.length / itemsPerPage);

  // Sayfa değişiminde işlem
  const handlePageChange = (page) => {
    setCurrentPage(page);
    window.scrollTo(0, 0); // Sayfa değişiminde yukarı kaydır
  };

  // Sıralama Okları
  const getSortIcon = (key) => {
    if (sortConfig.key === key) {
      return sortConfig.direction === 'asc' ? '▲' : '▼';
    }
    return '▲'; // Varsayılan sıralama yukarı
  };

  return (
    <Container className="py-5">
      <Button color="success" className="mb-4" onClick={handleAddCourse}>
        Add New Course
      </Button>
      <div className="mb-3 d-flex gap-3">
        <Input
          placeholder="Filter by title"
          onChange={(e) => handleFilter('title', e.target.value)}
        />
        <Input
          placeholder="Filter by category"
          onChange={(e) => handleFilter('category', e.target.value)}
        />
      </div>
      <Table bordered hover className="table bg-white rounded">
        <thead>
          <tr>
            <th>#</th>
            <th onClick={() => handleSort('title')} style={{ cursor: 'pointer' }}>
              Title {getSortIcon('title')}
            </th>
            <th onClick={() => handleSort('category')} style={{ cursor: 'pointer' }}>
              Category {getSortIcon('category')}
            </th>
            <th onClick={() => handleSort('price')} style={{ cursor: 'pointer' }}>
              Price {getSortIcon('price')}
            </th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {currentPageData.map((course, index) => (
            <tr key={course.id}>
              <th scope="row">{startIndex + index + 1}</th>
              <td>{course.title}</td>
              <td>{course.category}</td>
              <td>{course.price}</td>
              <td>
                <Button color="warning" size="sm" className="me-2" onClick={() => handleEdit(course.id)}>
                  Edit
                </Button>
                <Button color="danger" size="sm" onClick={() => handleDelete(course.id)}>
                  Delete
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

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

export default TeacherPage;
