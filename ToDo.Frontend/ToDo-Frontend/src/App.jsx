import { createBrowserRouter, RouterProvider } from "react-router-dom"
import HomePage from "./pages/homePage"
import ErrorPage from "./pages/ErrorPage"
import ToDoPage from "./pages/ToDoPage"

const router = createBrowserRouter(
  [
    {
      path: "/",
      element: <HomePage />,
      errorElement: <ErrorPage />
    },
    {
      path: `/todos/:id`,
      element: <ToDoPage></ToDoPage>,
      errorElement: <ErrorPage></ErrorPage>
    }
  ]
)

function App() {

  return <RouterProvider router={router}></RouterProvider>
}

export default App
