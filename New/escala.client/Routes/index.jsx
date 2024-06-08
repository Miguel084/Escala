import App from "@/App.jsx";
import { Route, Routes } from "react-router-dom";
import Home from "@/Pages/Home.jsx";
import Locais from "@/Pages/Locais.jsx";

const rotasPublicas = [
    {
        path: "/",
        element:<Home/>,
    },
    {
        path: "/Locais",
        element: <Locais/>,
    },
]

function AppRoutes(){
    const routing = rotasPublicas.map((rota) => (
        <Route key={rota.path} path={rota.path} element={rota.element} />
    ));
    return (
        <>
            <Routes>
                {routing}
            </Routes>
        </>
    )
}
export default AppRoutes;