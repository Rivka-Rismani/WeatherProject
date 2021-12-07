import React, { useState, useRef } from 'react'
import { Container, Col, Row, Button } from "react-bootstrap";
import axios from "axios";
import "../styles/wether.css"
function Wether() {
 
    const [cities, setCities] = useState([])
    const city = useRef("");
    const [wether, setWether] = useState("");
    const [linlWether, setLinkWether] = useState("");
    const [numFavoriteCities, setNumFavoriteCities] = useState()
    const [favoriteCities, setFavoriteCities] = useState()
    const path = `http://localhost:5236/api/`;
    const addCityToFavorites = (nameCity) => {
        debugger
        axios.post(`${path}Cities/AddFavoriteCity`, { cityName: nameCity }).then(x => {
            setNumFavoriteCities(numFavoriteCities + 1)
            getsetFavoriteCities()
            setNumFavoriteCities(favoriteCities.length)


        }).catch((err) => {
            console.error('erorr!', err)
        });
    }
    const getsetFavoriteCities = async () => {
        debugger
        await axios.get(`${path}Cities/GetFavoriteCitiesNames`).then(response => {
            console.log(response.data)
            setFavoriteCities(response.data)
            console.log(response.data.length)

        }).catch((err) => {
            console.error('erorr!', err)
        });
    }
    const getCity = (text) => {
        debugger
        axios.get(` http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=q7XOzbjadqTorzIEMkGwnwGbF2sSnaKh&q=${text}`)
            .then(function (response) {
                setCities(response.data)
            })
            .catch((err) => {
                console.error('erorr!', err)
            });
    }

    const getCurrentWeathe = (key, name) => {
        debugger
        setCities([])
        city.current.value = name
        axios.get(`http://dataservice.accuweather.com/forecasts/v1/daily/1day/${key}?apikey=q7XOzbjadqTorzIEMkGwnwGbF2sSnaKh `)
            .then(function (response) {
                setWether(response.data.Headline["Text"])
                setLinkWether(response.data.Headline["Link"])
            })
            .catch((err) => {
                console.error('erorr!', err)
            });
    }
    return (
        <>
            <Container>
                <Row>
                    <Col><h1 className='headline'>There are {numFavoriteCities} favorite cities</h1></Col>
                </Row>
                <Row className='serch'>
                    <Col className='content' ><Button
                        onClick={(e) => addCityToFavorites(city.current.value)

                        }
                    >add to Favorites</Button></Col>
                    <Col className='content'><input type='text' ref={city} placeholder='serch....' onChange={(e) => getCity(city.current.value)}></input></Col>
                </Row>
                <Row className='cities'>
                    {cities.length > 0 &&
                        cities.map((item) => (
                            <Col><Button onClick={(e) => getCurrentWeathe(item.Key, item.LocalizedName)}>
                                {item.LocalizedName}

                            </Button></Col>
                        ))
                    }
                    {favoriteCities &&
                        <Col>
                            <div className='favoriteCities'>favorites cities</div>
                            <ul>
                                {favoriteCities.map((item) => {
                                    return <li>{item}</li>
                                })}
                            </ul>

                        </Col>
                    }
                </Row>

                <Row>
                    <Col className='wether'>
                        {wether !== "" ? wether : "......"}
                    </Col>
                    {linlWether &&
                        <Col className='linkWether'> <a
                            href={`${linlWether}`}
                            rel="noreferrer" target="_blank" >link to the wether</a></Col>
                    }
                </Row>
            </Container>
            <footer>Name:Rivka Rismani</footer>
        </>)
}

export default Wether