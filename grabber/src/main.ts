import cluster from "node:cluster";
import { cpus } from "node:os";
import { createWriteStream } from "node:fs";
import { get } from "node:https";
import { resolve } from "node:path";
import { Browser, chromium } from "playwright";

async function getImagesLinks(browser: Browser) {
  const context = await browser.newContext({ proxy: { server: `SOCKS4://212.115.232.79:10800` } });
  const page = await context.newPage();

  try {
    await page.goto(`https://kenzato.uk/booru/category/HS2/?page=${cluster.worker?.id}`, { waitUntil: "networkidle" });
    return [];
    // return page.evaluate<string[]>(() => {
    //   const imgs = document.querySelectorAll<HTMLImageElement>(".jsly-loaded");
    //   return Array.from(imgs).map((img) => img.src);
    // });
  } finally {
    // await page.close();
  }
}

async function test(browser: Browser) {
  const links = await getImagesLinks(browser);
  return Promise.allSettled(links.map((e) => get(e, (response) => response.pipe(createWriteStream(resolve("result", `${Date.now()}.png`))))));
}

if (cluster.isPrimary) {
  (async () => {
    const browser = await chromium.launchServer({ devtools: true, proxy: { server: "http://per-context" } });

    cpus()
      .slice(0, 1)
      .forEach((_) => {
        cluster.fork({ WS: browser.wsEndpoint() });
      });
  })();
} else {
  (async () => {
    const browser = await chromium.connect(String(process.env.WS));

    await test(browser);
  })();
}
