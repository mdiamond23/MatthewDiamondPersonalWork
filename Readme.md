Hello. My name is Matthew Diamond and I'm a CS student at the University of Michigan. I am vert passionate about Game Development. Here are some code examples I have.

AnchorBuildingManager.cs, BuildingDecay.cs, BuildingPlacer.CS:
These scripts are part of Unity project. The project is rich RTS game featuring sandpeople and bugs. I mainly focoused on the building syestem. I was tasked to create a building decay system for these buildings. To accomplish this, I used an anchor building, which is defined in AnchorBuildingManager.cs. Then, In BuildingDecay.cs, I used for loops to check if a building was in range of one of these anchor buildings, where the building would slowly die if it wasn't in range of one of these buildings. In BuildingPlacer, the player is provided with visuals of whether it is "safe" to place a building. I added the visuals in this script, but nothing else. Additionally, in Anchor Building mnanager, I did some calculations that were necessary to accurately depict saftey range using a URP projector
