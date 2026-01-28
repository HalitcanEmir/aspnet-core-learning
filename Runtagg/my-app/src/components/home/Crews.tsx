"use client";

import { motion } from "framer-motion";
import SectionWrapper from "./SectionWrapper";

const crewCards = [
  {
    title: "Game Crew",
    description: "Indie, jam and competition games across PC, mobile and web.",
    tags: ["Unity", "Unreal", "Godot"],
    lookingFor: "Developers, Artists, Sound",
  },
  {
    title: "Web Crew",
    description:
      "Product builders for dashboards, SaaS and full-stack student projects.",
    tags: ["Next.js", "Django", "FastAPI"],
    lookingFor: "Full-stack, UI/UX, PM",
  },
  {
    title: "AI / Data Crew",
    description:
      "From tiny ML demos to data-heavy competition cases and research PoCs.",
    tags: ["Python", "ML", "Data"],
    lookingFor: "ML, Data, Backend",
  },
  {
    title: "Competition Crew",
    description:
      "Focused teams for Teknofest and global hackathons with clear deadlines.",
    tags: ["Teknofest", "Hackathons"],
    lookingFor: "Leads, Builders, Operators",
  },
];

export default function Crews() {
  return (
    <SectionWrapper id="crews" className="space-y-10">
      <div className="flex flex-col gap-6 lg:flex-row lg:items-end lg:justify-between">
        <div className="space-y-3">
          <p className="text-[11px] font-semibold uppercase tracking-[0.3em] text-slate-400">
            Crews
          </p>
          <h2 className="text-2xl font-semibold uppercase tracking-[0.18em] text-slate-100 sm:text-3xl">
            Teams built around ideas
          </h2>
          <p className="max-w-xl text-sm text-slate-300">
            Instead of a fixed company org-chart, we build flexible crews.
            Developers, artists and makers group up to ship specific projects.
          </p>
        </div>
        <a
          href="#join"
          className="text-xs font-semibold uppercase tracking-[0.28em] text-sky-300 hover:text-sky-200"
        >
          How to join →
        </a>
      </div>

      <div className="grid gap-5 md:grid-cols-2">
        {crewCards.map((crew, index) => (
          <motion.article
            key={crew.title}
            initial={{ opacity: 0, y: 20 }}
            whileInView={{ opacity: 1, y: 0 }}
            viewport={{ once: true, margin: "0px 0px -20% 0px" }}
            transition={{ duration: 0.5, delay: index * 0.08 }}
            className="glass-panel-subtle group relative flex flex-col justify-between gap-4 border border-white/10 p-5 transition duration-200 hover:-translate-y-1 hover:border-sky-400/70"
          >
            <div className="flex items-center justify-between gap-2">
              <h3 className="text-sm font-semibold uppercase tracking-[0.24em] text-slate-100">
                {crew.title}
              </h3>
              <span className="rounded-full border border-emerald-400/30 bg-emerald-500/10 px-3 py-1 text-[10px] uppercase tracking-[0.25em] text-emerald-300">
                Open slots
              </span>
            </div>
            <p className="text-xs leading-relaxed text-slate-300/90">
              {crew.description}
            </p>
            <div className="flex flex-wrap gap-2">
              {crew.tags.map((tag) => (
                <span
                  key={tag}
                  className="rounded-full bg-slate-900/70 px-3 py-1 text-[10px] uppercase tracking-[0.22em] text-slate-300"
                >
                  {tag}
                </span>
              ))}
            </div>
            <div className="pt-1 text-[11px] text-slate-400">
              Looking for:{" "}
              <span className="text-slate-200">{crew.lookingFor}</span>
            </div>
          </motion.article>
        ))}
      </div>
    </SectionWrapper>
  );
}

