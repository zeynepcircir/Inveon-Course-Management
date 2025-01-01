import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AppNavbar from './components/Navbar/Navbar';
import Sidebar from './components/Sidebar/Sidebar';
import HomePage from './pages/HomePage/HomePage';
import CourseDetailPage from './pages/CourseDetailPage/CourseDetailPage';
import LoginPage from './pages/LoginPage/LoginPage';
import RegisterPage from './pages/RegisterPage/RegisterPage';
import TeacherPage from './pages/TeacherPage/TeacherPage';
import DashboardPage from './pages/DashboardPage/DashboardPage';
import AddCoursePage from './pages/AddCoursePage/AddCoursePage';
import EditCoursePage from './pages/EditCoursePage/EditCoursePage';
import { CartProvider } from './components/Context/CartContex';
import PaymentPage from './pages/PaymentPage/PaymentPage';

function App() {
  return (
    <CartProvider>
    <Router>
      <div className="d-flex flex-column" style={{ minHeight: '100vh' }}>
        {/* Navbar */}
        <AppNavbar />
        
        <div className="d-flex flex-grow-1">
          {/* Sidebar */}
          <div className="bg-light border-end" style={{ width: '250px' }}>
            <Sidebar />
          </div>
          
          {/* Main Content */}
          <div className="flex-grow-1 p-4">
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/course/:id" element={<CourseDetailPage />} />
              <Route path="/login" element={<LoginPage />} />
          <Route path="/browse" element={<HomePage />} />
              <Route path="/register" element={<RegisterPage />} />
              <Route path="/dashboard" element={<DashboardPage />} />
              <Route path="/teacher" element={<TeacherPage />} />
              <Route path="/teacher/add" element={<AddCoursePage />} />
              <Route path="/teacher/edit/:id" element={<EditCoursePage />} />
              <Route path="/payment" element={<PaymentPage/>} />
            </Routes>
          </div>
        </div>
      </div>
    </Router>
    </CartProvider>
  );
}

export default App;
