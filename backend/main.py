from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
from typing import Optional

app = FastAPI()

# Simulation state (in-memory)
simulation_state = {
    "sun": {"altitude": 45.0, "azimuth": 180.0},
    "panel": {"tilt": 30.0, "rotation": 180.0}
}

# Request/Response models
class SunData(BaseModel):
    altitude: float  # degrees
    azimuth: float   # degrees

class PanelData(BaseModel):
    tilt: float       # vertical angle (elevation)
    rotation: float   # horizontal angle (azimuth)

class SimulationData(BaseModel):
    sun: Optional[SunData]
    panel: Optional[PanelData]

@app.get("/simulation")
def get_simulation():
    return simulation_state

@app.post("/simulation")
def update_simulation(data: SimulationData):
    if data.sun:
        simulation_state["sun"] = data.sun.model_dump()
    if data.panel:
        simulation_state["panel"] = data.panel.model_dump()
    return {"message": "Simulation updated", "state": simulation_state}
