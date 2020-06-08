exports.config = {
  projectRoot: "./src",
  projectName: "revive-vzw",
  outDir: './dist/static',
  routes: {
    '/calendar-detail/:id': {
      type: 'json',
      id: {
        url: 'https://revivevzwapi.azurewebsites.net/api/activity/upcoming',
        property: 'id'
      }
    }
  }
};