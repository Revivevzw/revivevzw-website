// exports.config = {
//   projectRoot: "./src",
//   projectName: "revive-vzw",
//   outDir: './dist/static',
//   routes: {
//     '/calendar-detail/:id': {
//       type: 'json',
//       id: {
//         url: 'https://revivevzwapi.azurewebsites.net/api/activity/upcoming',
//         property: 'id'
//       }
//     }
//   }
// };

import { ScullyConfig, setPluginConfig } from '@scullyio/scully';
// import { GoogleAnalytics } from '@scullyio/scully-plugin-google-analytics';

// const defaultPostRenderers = [];
// setPluginConfig(GoogleAnalytics, { globalSiteTag: 'G-64TMQJS06N' });
// defaultPostRenderers.push(GoogleAnalytics);

export const config: ScullyConfig = {
  puppeteerLaunchOptions: {executablePath: '@scullyio/scully/node_modules/puppeteer/.local-chromium/linux-818858'},
  projectRoot: './src',
  projectName: 'revive-vzw',
  outDir: './dist/static',
  // defaultPostRenderers,
  routes: {
    // '/': {
    //   type: 'contentFolder',
    //   postRenderers: [...defaultPostRenderers],
    // },
    '/calendar-detail/:id': {
      type: 'json',
      id: {
        url: 'https://revivevzwapi.azurewebsites.net/api/activity/upcoming',
        property: 'id'
      }
    },
    '/missions/:id': {
      type: 'json',
      id: {
        url: 'https://revivevzwapi.azurewebsites.net/api/mission/all',
        property: 'id'
      }
    }
  }
};