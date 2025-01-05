# **Inveon Course Management** 🚀

Inveon Course Management is a modern web application that allows users to explore, purchase, and manage various courses. It features a dynamic user interface developed with React and a robust backend built with ASP.NET Core API. The system uses JWT-based authentication and authorization for secure user access.

## Features ✨

- **User Registration & Login:** Users can register with email and password, log in, and manage their profiles.
- **Course Listing & Search:** View all courses and search by course name.
- **Course Detail Page:** Users can view the details of each course and make purchases.
- **Profile Page:** Users can view their purchased courses, update profile information, and change passwords.
- **JWT-based Security:** Secure login is ensured with JWT-based authentication.
- **Responsive Design:** Fully responsive for a seamless experience on mobile devices.

## Technologies 🛠️

- **Frontend:** 
  - React
  - React Router
  - Redux or Context API (State Management)
  - Axios (API Requests)
  - JWT (Authentication)
  - Material UI or Bootstrap (UI Library)
  
- **Backend:** 
  - ASP.NET Core Web API
  - Entity Framework (Database Access)
  - JWT (Authentication and Authorization)

- **Database:** 
  - SQL Server


## Login For Instructor🧑🏻‍🏫
```http
Body (JSON):
{
  "email": "instructor@example.com",
  "password": "Instructor123!"
}
```
## Login For Student🛠👩‍🎓
```http
Body (JSON):
{
  "email": "student@example.com",
  "password": "Student123!"
}
```

## Setup 📥

### 1. Clone the Repository

To clone the project to your local machine, run:

```bash
git clone https://github.com/zeynepcircir/Inveon-Course-Management.git
cd Inveon-Course-Management

```


</br>

<div align="center">

| Login Screen  | Register Screen | Dashboard Screen | 
| ------------- | ------------- | ------------- |
| ![login.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/login.png) | ![register.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/register.png)  | ![slider.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/slider.png)  |

| Browse Screen | Payment Screen | 
| ------------- | ------------- |
| ![dashboard.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/dashboard.png) | ![payment.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/payment.png) | 

</div>

# **How It Works?**
- Bookmark or delete from bookmarks any course with the bookmark button on the right corner of the course poster
- If a course appears in more than one section, it will bookmark automatically all of the occurrences of that course 
- Can use a tab bar to see all bookmarked courses
- Can see the detail page by selecting a specific row

</br>

<div align="center">

| Teacher Mode Screen  | Courses | Dark Mode | Course Chapters Screen |
| ------------- | ------------- | ------------- | ------------- |
| ![teachermode.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/teachermode.png) | ![browse.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/browse.png)  | ![dark.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/dark.png)  | ![coursedetail.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/coursedetail.png)  |

| Cart Screen | Add Course Screen | About Screen |
| --- | --- | --- |
| ![cart.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/cart.png) | ![addcourse.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/addcourse.png) | ![about.png](https://github.com/zeynepcircir/Inveon-Course-Management/blob/master/photos/about.png) |

| ER Diagram | ER Diagram | Swagger |
| --- | --- | --- |
| ![cart.png](https://github.com/user-attachments/assets/3ec49cca-d75c-42dd-b4f9-55cf592d5247)
) | ![addcourse.png](https://github.com/user-attachments/assets/14d45a96-0c1b-4800-812f-0e2f9446f665)
) | ![about.png](https://github.com/user-attachments/assets/89d28e4e-80d5-4b65-bc52-3b02e475f261)
) |

</div>

