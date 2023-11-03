import React from 'react'
import PropTypes from 'prop-types';
import './App.css'
import Grid from './ui/Grid.Component';

function App({ repositories }) {
  return (
    <Grid marsRoverRepository={repositories.marsRover} />
  )
}

App.propTypes = {
  repositories: PropTypes.shape({
    marsRover: PropTypes.shape({
      sendCommands: PropTypes.func.isRequired,
    }).isRequired,
  }).isRequired,
}

export default App
