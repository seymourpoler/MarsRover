import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { MarsRoverView } from "./components/MarsRover/MarsRoverView";
import MyComponent from "./components/MyComponent";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/mars-rover',
    element: <MarsRoverView />
  },
  {
    path: '/people',
    element: <MyComponent />
  }
];

export default AppRoutes;
