const API_ENDPOINTS = {
  auth: {
    login: '/Authentication/login',
    register: '/Authentication/register',
  },
  category: {
    getAll: '/Category',
  },
  course: {
    getAll: '/Course',
    create: '/Course',
    getById: (id) => `/Course/${id}`,
    update: (id) => `/Course/${id}`,
    delete: (id) => `/Course/${id}`,
    getChapters: (courseId) => `/Course/${courseId}/chapters`,
    getStudentChapters: (courseId) => `/Course/${courseId}/studentChapters`,
    enrolledCourses: '/Course/enrolledCourses',
    instructorCourses: '/Course/instructorCourses',
    addToCart: (courseId) => `/Course/${courseId}/addToCart`,
    getCartCourses: '/Course/cartCourses'
  },
  payment: {
    makePayment: '/Payment',
  },
};

export default API_ENDPOINTS;
